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
using Azure.Storage.Blobs;
using System.IO;
using VehicleExport.App.Models.Data.Destinations;
using VehicleExport.Core.Utilities;
using VehicleExport.App.Services.Data.ExportDealerParameters;
using VehicleExport.App.Services.Data.Exports;
using VehicleExport.App.Services.Data.Layouts;
using VehicleExport.App.Services.Data.LayoutFieldsMap;
using VehicleExport.App.Services.Data.LayoutFields;

namespace VehicleExport.App.Services.Data.ExportDealers
{
    public class ExportDealerService : EntityWriteService<ExportDealer, int>
    {
        private ExportDealerParameterService _exportDealerParameterService;
        private ExportService _exportService { get; set; }
        private LayoutService _layoutService { get; set; }
        private LayoutFieldsService _layoutFieldsService { get; set; }
        private LayoutFieldsMapService _layoutFieldsMapService { get; set; }
        public ExportDealerService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<ExportDealer> validator, ILogger<ExportDealerService> logger
            ,ExportDealerParameterService exportDealerParameterService
            ,ExportService exportService
            ,LayoutService layoutService
            ,LayoutFieldsMapService layoutFieldsMapService
            ,LayoutFieldsService layoutFieldsService) : base(dbContext, configuration, userManager, validator, logger)
        {
            _exportDealerParameterService = exportDealerParameterService;
            _exportService = exportService;
            _layoutService = layoutService;
            _layoutFieldsMapService = layoutFieldsMapService;
            _layoutFieldsService = layoutFieldsService;
        }

        protected override async Task<IQueryable<ExportDealer>> ApplyIdFilter(IQueryable<ExportDealer> queryable, int id)
        {
            return queryable.Where(x => x.ExportDealerId == id);
        }

        protected override async Task OnCreated(ClaimsPrincipal user, ExportDealer dataModel, Dictionary<string, object> extraData)
        {
            //Find export layout for dealer, get the layout parameters off
            var export = await _exportService.GetOne(user, dataModel.ExportId, null);
            var layout = await _layoutService.GetOne(user, export.LayoutId, null);
            var layoutFields = await _layoutFieldsMapService.GetAll(user, 0, 100000, null, null, $"layoutId=\"{layout.LayoutId}\"");
            //LayoutFieldTypeId 2 = Parameter
            foreach(var layoutField in layoutFields)
            {
                var layoutFieldDefinition = await _layoutFieldsService.GetOne(user, layoutField.LayoutFieldId, null);
                if(layoutFieldDefinition.LayoutFieldTypeId == (int)LayoutFieldTypeIds.Parameter)
                {
                    var newExportDealerParameter = await _exportDealerParameterService.GetNew(user, null);
                    newExportDealerParameter.ExportDealerId = dataModel.ExportDealerId;
                    newExportDealerParameter.LayoutFieldId = layoutFieldDefinition.LayoutFieldId;
                    newExportDealerParameter.dtmCreated = DateTime.Now;
                    await _exportDealerParameterService.Create(user, newExportDealerParameter);
                }
            }
        }

        protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };
        protected override List<string> WriteRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager };
    }
}
