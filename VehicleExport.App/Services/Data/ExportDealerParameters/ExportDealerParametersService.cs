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

namespace VehicleExport.App.Services.Data.ExportDealerParameters
{
    //public class ExportDealerParameterService : EntityWriteService<ExportDealerParameter, int>
    //{
    //    public ExportDealerParameterService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<ExportDealerParameter> validator, ILogger<ExportDealerParameterService> logger) : base(dbContext, configuration, userManager, validator, logger)
    //    {
           
    //    }

    //    protected override async Task<IQueryable<ExportDealerParameter>> ApplyIdFilter(IQueryable<ExportDealerParameter> queryable, int id)
    //    {
    //        return queryable.Where(x => x.ExportId == id);
    //    }

    //    protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };
    //    protected override List<string> WriteRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager };
    //}
}
