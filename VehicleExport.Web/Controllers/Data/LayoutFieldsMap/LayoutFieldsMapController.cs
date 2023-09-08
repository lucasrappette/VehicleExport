using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using VehicleExport.App.Models.Data.Donors;
using VehicleExport.App;
using VehicleExport.App.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.LayoutFieldsMap;

namespace VehicleExport.Web.Controllers.Data.LayoutFieldsMap
{
    [Authorize]
    public class LayoutFieldsMapController : EntityWriteController<LayoutFieldMap, IEntityWriteService<LayoutFieldMap, int>, int>
    {
        public LayoutFieldsMapController(IConfiguration configuration, IEntityWriteService<LayoutFieldMap, int> service) : base(configuration, service)
        {
        }
    }
}
