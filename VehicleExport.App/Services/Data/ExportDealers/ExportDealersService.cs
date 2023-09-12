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
using VehicleExport.App.Models.Data.ExportDealerParameters;
using VehicleExport.App.Models.Data.ExportDealers;

namespace VehicleExport.App.Services.Data.ExportDealers
{
    public class ExportDealerService : EntityWriteService<ExportDealer, int>
    {
        public ExportDealerService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<ExportDealer> validator, ILogger<ExportDealerService> logger) : base(dbContext, configuration, userManager, validator, logger)
        {

        }

        protected override async Task<IQueryable<ExportDealer>> ApplyIdFilter(IQueryable<ExportDealer> queryable, int id)
        {
            return queryable.Where(x => x.ExportDealerId == id);
        }

        protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };
        protected override List<string> WriteRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager };
    }
}
