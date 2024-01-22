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
using VehicleExport.App.Models.Data.ExportDealerParameters;

namespace VehicleExport.Web.Controllers.Data.ExportDealerParameters
{
    [Authorize]
    public class ExportDealerParametersController : EntityWriteController<ExportDealerParameter, IEntityWriteService<ExportDealerParameter, int>, int>
    {
        public ExportDealerParametersController(IConfiguration configuration, IEntityWriteService<ExportDealerParameter, int> service) : base(configuration, service)
        {
        }
    }
}
