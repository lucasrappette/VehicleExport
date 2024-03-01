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
using VehicleExport.App.Models.Data.ExportDealers;
using VehicleExport.App.Services.Data.ExportDealers;
using VehicleExport.App.Services.Data.ExportDealerParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VehicleExport.Web.Middleware.Exceptions;
using System.Dynamic;

namespace VehicleExport.Web.Controllers.Data.ExportDealers
{
    [Authorize]
    public class ExportDealersController : EntityWriteController<ExportDealer, IEntityWriteService<ExportDealer, int>, int>
    {
        ExportDealerService _exportDealersService;
        ExportDealerParameterService _exportDealerParameterService;
        public ExportDealersController(IConfiguration configuration, IEntityWriteService<ExportDealer, int> service, ExportDealerService exportDealerService, ExportDealerParameterService exportDealerParameterService) : base(configuration, service)
        {
            _exportDealerParameterService = exportDealerParameterService;
            _exportDealersService = exportDealerService;
        }

        [HttpPut("saveExportDealerAndParameters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SaveExportDealerAndParameters([FromBody] ExpandoObject dtoModel, string context = null)
        {

            ExportDealer dataModel = ConvertToDataModel(dtoModel, context);
            foreach(var exportDealerParameter in dataModel.ExportDealerParameters)
            {
                if (exportDealerParameter.ExportDealerParameterId == 0)
                {
                    exportDealerParameter.LayoutField = null;
                    await _exportDealerParameterService.Create(HttpContext.User, exportDealerParameter);
                }
                else
                    await _exportDealerParameterService.Update(HttpContext.User, exportDealerParameter);
            }

            dataModel = await _writeService.Update(HttpContext.User, dataModel);

            object returnValue = ConvertToDTO(dataModel, "", context);

            return Ok(returnValue);
        }
    }
}
