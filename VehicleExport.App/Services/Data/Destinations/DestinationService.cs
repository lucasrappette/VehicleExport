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
            //Needs to save checksum for file
            var blobName = Guid.NewGuid().ToString();

            var blobServiceClient = new BlobServiceClient(_configuration.GetValue<string>("AzureBlobStorage"));
            var containerName = "sshkeyfiles";
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(dataModel.SshFile.OpenReadStream());

            dataModel.SSHKeyFileName = blobName;

            await Update(user, dataModel);
        }

        public async Task<Destination> UploadFile(ClaimsPrincipal user, Guid? clientId, IFormFile file)
        {
            var applicationUser = await GetApplicationUser(user);
            var blobName = Guid.NewGuid().ToString();

            var markDownImage = new Destination()
            {
                /*ClientId = clientId,
                BlobName = blobName,
                ContentType = file.ContentType,
                Uploaded = DateTime.UtcNow*/
            };

            if (!await CanCreate(applicationUser, markDownImage, new Dictionary<string, object>()))
                throw new ForbiddenException();

            var blobServiceClient = new BlobServiceClient(_configuration.GetValue<string>("AzureBlobStorage"));
            var containerName = "sshkeyfiles";
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(file.OpenReadStream());

            var newMarkDownImage = await Create(user, markDownImage);

            return newMarkDownImage;
        }

        public async Task<Tuple<Destination, Stream>> DownloadFile(ClaimsPrincipal user, int id)
        {
            var applicationUser = await GetApplicationUser(user);
            var markDownImage = await GetOne(user, id, null);

            var blobServiceClient = new BlobServiceClient(_configuration.GetValue<string>("AzureBlobStorage"));
            var containerName = "sshkeyfiles";
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(markDownImage.SSHKeyFileName);
            var content = await blobClient.DownloadContentAsync();

            return new Tuple<Destination, Stream>(markDownImage, content.Value.Content.ToStream());
        }

        protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };
        protected override List<string> WriteRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager };
    }
}
