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
using VehicleExport.App.Models.Data.Exports;

namespace VehicleExport.Web.Controllers.Data.Exports
{
    [Authorize]
    public class ExportTrackingController : EntityWriteController<ExportTracking, IEntityWriteService<ExportTracking, int>, int>
    {
        public ExportTrackingController(IConfiguration configuration, IEntityWriteService<ExportTracking, int> service) : base(configuration, service)
        {
        }
    }
}
