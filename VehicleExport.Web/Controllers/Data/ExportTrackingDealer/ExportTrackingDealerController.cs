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
    //[Authorize]
    //public class ExportTrackingDealerController : EntityWriteController<ExportTrackingDealer, IEntityWriteService<ExportTrackingDealer, int>, int>
    //{
    //    public ExportTrackingDealerController(IConfiguration configuration, IEntityWriteService<ExportTrackingDealer, int> service) : base(configuration, service)
    //    {
    //    }
    //}
}
