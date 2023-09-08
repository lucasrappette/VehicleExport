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
using VehicleExport.App.Models.Data.MinorEntity;

namespace VehicleExport.App.Services.Data.MinorEntity
{
    public class ProtocolTypeService : EntityReadService<ProtocolType, short>
    {
        public ProtocolTypeService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<ProtocolType> validator, ILogger<ProtocolTypeService> logger) : base(dbContext, configuration, userManager, logger)
        {
           
        }

        protected override async Task<IQueryable<ProtocolType>> ApplyIdFilter(IQueryable<ProtocolType> queryable, short id)
        {
            return queryable.Where(x => x.ProtocolTypeId == id);
        }

        protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };

    }
}
