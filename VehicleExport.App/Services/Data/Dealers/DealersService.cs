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
using VehicleExport.App.Models.Data;
using VehicleExport.App.Services.Data;

namespace VehicleExport.App.Services.Data
{
    public class DealersService : EntityReadService<Dealers, int>
    {
        public DealersService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, ILogger<DealersService> logger) : base(dbContext, configuration, userManager, logger)
        {
        }

        protected override async Task<IQueryable<Dealers>> ApplyIdFilter(IQueryable<Dealers> queryable, int id)
        {
            return queryable.Where(x => x.DealerId == id);
        }

        protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };
    }
}
