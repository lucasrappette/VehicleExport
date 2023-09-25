using FluentValidation;
using VehicleExport.App.DAL;
using VehicleExport.App.Models.Data.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Donors;
using VehicleExport.App.Models;
using System.Collections.Generic;
using VehicleExport.Core.Models;
using VehicleExport.App.Services.WorkItems;
using VehicleExport.App.Models.Data.Destinations;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System.IO;
using VehicleExport.App.Exceptions;
using VehicleExport.Core.Utilities;

namespace VehicleExport.App.Services.Data.Destinations
{
    public class DestinationService : EntityWriteService<Destination, int>
    {
        public DestinationService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<Destination> validator, ILogger<DestinationService> logger) : base(dbContext, configuration, userManager, validator, logger)
        {
           
        }

        protected override async Task<IQueryable<Destination>> ApplyIdFilter(IQueryable<Destination> queryable, int id)
        {
            return queryable.Where(x => x.DestinationId == id);
        }

        protected override async Task OnCreating(ClaimsPrincipal user, Destination dataModel, Dictionary<string, object> extraData) 
        {
            dataModel.dtmCreated = DateTime.Now;
        }

        protected virtual async Task OnUpdating(ClaimsPrincipal user, Destination dataModel, Dictionary<string, object> extraData) 
        {
            dataModel.dtmLastChanged = DateTime.Now;
        }

        protected override async Task OnCreated(ClaimsPrincipal user, Destination dataModel, Dictionary<string, object> extraData)
        {
            if (dataModel.SshFile != null)
            {
                //Needs to save checksum for file
                using (var readStream = dataModel.SshFile.OpenReadStream())
                {
                    var blobName = Guid.NewGuid().ToString();

                    var blobServiceClient = new BlobServiceClient(_configuration.GetValue<string>("AzureBlobStorage"));
                    var containerName = "sshkeyfiles";
                    var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                    await containerClient.CreateIfNotExistsAsync();

                    var blobClient = containerClient.GetBlobClient(blobName);
                    await blobClient.UploadAsync(readStream);
                    readStream.Seek(0, SeekOrigin.Begin);
                    dataModel.SSHKeyFileName = blobName;
                    dataModel.SshKeyFileChecksum = EncryptionUtilities.GetFileChecksum(readStream);


                    await Update(user, dataModel);
                }
            }
        }
        protected override async Task OnUpdated(ClaimsPrincipal user, Destination dataModel, Destination oldDataModel, Dictionary<string, object> extraData)
        {
            if (dataModel.SshFile != null)
            {
                using (var readStream = dataModel.SshFile.OpenReadStream())
                {
                    if (dataModel.SshKeyFileChecksum == null || (dataModel.SshKeyFileChecksum != EncryptionUtilities.GetFileChecksum(readStream)))
                    {
                        var blobName = Guid.NewGuid().ToString();

                        var blobServiceClient = new BlobServiceClient(_configuration.GetValue<string>("AzureBlobStorage"));
                        var containerName = "sshkeyfiles";
                        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                        await containerClient.CreateIfNotExistsAsync();

                        var blobClient = containerClient.GetBlobClient(blobName);
                        await blobClient.UploadAsync(readStream);
                        readStream.Seek(0, SeekOrigin.Begin);
                        dataModel.SSHKeyFileName = blobName;
                        dataModel.SshKeyFileChecksum = EncryptionUtilities.GetFileChecksum(readStream);
                        await Update(user, dataModel);
                    }
                    //SSH File Deleted
                    else if (oldDataModel.SSHKeyFileName != null && dataModel.SSHKeyFileName == null)
                    {
                        dataModel.SshKeyFileChecksum = null;
                        var blobServiceClient = new BlobServiceClient(_configuration.GetValue<string>("AzureBlobStorage"));
                        var containerName = "sshkeyfiles";
                        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                        await containerClient.CreateIfNotExistsAsync();

                        var blobClient = containerClient.GetBlobClient(oldDataModel.SSHKeyFileName);
                        await blobClient.DeleteAsync();
                        await Update(user, dataModel);
                    }
                }
            }
        }

        public async Task<Stream> DownloadFile(ClaimsPrincipal user, string sshKeyFileName)
        {
            var blobServiceClient = new BlobServiceClient(_configuration.GetValue<string>("AzureBlobStorage"));
            var containerName = "sshkeyfiles";
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(sshKeyFileName);
            var content = await blobClient.DownloadContentAsync();

            return content.Value.Content.ToStream();
        }

        protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };
        protected override List<string> WriteRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager };
    }
}
