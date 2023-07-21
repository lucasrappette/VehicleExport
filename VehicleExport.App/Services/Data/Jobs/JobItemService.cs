using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VehicleExport.App.DAL;
using VehicleExport.App.Models.Data.Accounts;
using VehicleExport.App.Models.Data.Jobs;
using VehicleExport.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExport.App.Services.Data.Jobs
{
    public class JobItemService : EntityWriteService<JobItem, Guid>
    {

        public JobItemService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<JobItem> validator, ILogger<EntityWriteService<JobItem, Guid>> logger) : base(dbContext, configuration, userManager, validator, logger)
        {
        }

        protected override async Task<IQueryable<JobItem>> ApplyIdFilter(IQueryable<JobItem> queryable, Guid id)
        {
            return queryable.Where(x => x.Id == id);
        }

        protected override async Task<IQueryable<JobItem>> ApplyReadSecurity(ApplicationUser applicationUser, IQueryable<JobItem> queryable)
        {
            // Site admins can read all users
            if (await _userManager.IsInRoleAsync(applicationUser, ApplicationRoleNames.SuperAdmin))
                return queryable;

            return queryable.Where(x => false);
        }

        protected override async Task<bool> CanWrite(ApplicationUser applicationUser, JobItem dataModel, Dictionary<string, object> extraData)
        {
            if (await _userManager.IsInRoleAsync(applicationUser, ApplicationRoleNames.SuperAdmin))
                return true;

            return false;
        }
    }
}
