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
    public class LayoutFieldTypeService : EntityReadService<LayoutFieldType, short>
    {
        public LayoutFieldTypeService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<LayoutFieldType> validator, ILogger<LayoutFieldTypeService> logger) : base(dbContext, configuration, userManager, logger)
        {
           
        }

        protected override async Task<IQueryable<LayoutFieldType>> ApplyIdFilter(IQueryable<LayoutFieldType> queryable, short id)
        {
            return queryable.Where(x => x.LayoutFieldTypeId == id);
        }

        protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };

    }
}
