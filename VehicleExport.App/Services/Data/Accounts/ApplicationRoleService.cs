using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using VehicleExport.App.DAL;
using VehicleExport.App.Models.Data;
using VehicleExport.App.Models.Data.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VehicleExport.App.Models;
using VehicleExport.Core.Models;
using FluentValidation;
using System.Security.Claims;
using VehicleExport.App.Utilities;

namespace VehicleExport.App.Services.Data.Accounts
{
    public class ApplicationRoleService : EntityWriteService<ApplicationRole, Guid>
    {
        public ApplicationRoleService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<ApplicationRole> validator, ILogger<EntityWriteService<ApplicationRole, Guid>> logger) : base(dbContext, configuration, userManager, validator, logger)
        {
        }

        protected override async Task<IQueryable<ApplicationRole>> ApplyIdFilter(IQueryable<ApplicationRole> queryable, Guid id)
        {
            return queryable.Where(x => x.Id == id);
        }

        protected override async Task<IQueryable<ApplicationRole>> ApplyReadSecurity(ApplicationUser applicationUser, IQueryable<ApplicationRole> queryable)
        {
            return queryable;
        }

        protected override async Task<bool> CanWrite(ApplicationUser applicationUser, ApplicationRole dataModel, Dictionary<string, object> extraData)
        {
            if (await _userManager.IsInRoleAsync(applicationUser, ApplicationRoleNames.SuperAdmin))
                return true;

            return false;
        }

        protected override async Task<bool> CanInclude(ApplicationUser applicationUser, string include)
        {
            // Site admins can read all users
            if (await _userManager.IsInRoleAsync(applicationUser, ApplicationRoleNames.SuperAdmin))
                return true;

            return false;
        }
    }
}
