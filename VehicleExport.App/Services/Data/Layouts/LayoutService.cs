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
using VehicleExport.App.Models.Data.Layouts;
using VehicleExport.App.Services.Data.LayoutFieldsMap;

namespace VehicleExport.App.Services.Data.Layouts
{
    public class LayoutService : EntityWriteService<Layout, int>
    {
        private LayoutFieldsMapService _fieldsMapService;
        public LayoutService(LayoutFieldsMapService fieldsMapService, ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<Layout> validator, ILogger<LayoutService> logger) : base(dbContext, configuration, userManager, validator, logger)
        {
            _fieldsMapService = fieldsMapService;
        }

        protected override async Task<IQueryable<Layout>> ApplyIdFilter(IQueryable<Layout> queryable, int id)
        {
            return queryable.Where(x => x.LayoutId == id);
        }

        public async Task<Layout> CloneLayout(ClaimsPrincipal user, Layout dataModel)
        {
            var layoutFieldMapping = await _fieldsMapService.GetAll(user, 0, 100000, null, null, $"layoutId={dataModel.LayoutId}", true);
            dataModel.LayoutId = 0;
            var result = await this.Create(user, dataModel);
            var newLayoutId = result.LayoutId;
            if(layoutFieldMapping != null)
            {
                foreach(var field in layoutFieldMapping)
                {
                    field.LayoutId = newLayoutId;
                    field.LayoutFieldsMapId = 0;
                    await _fieldsMapService.Create(user, field);
                }
            }
            result.LayoutFieldMappings = layoutFieldMapping;
            return result;
        }

        protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };
        protected override List<string> WriteRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager };
    }
}
