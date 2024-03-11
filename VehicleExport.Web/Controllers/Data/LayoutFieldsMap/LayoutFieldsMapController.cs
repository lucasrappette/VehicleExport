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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using VehicleExport.Web.Middleware.Exceptions;
using VehicleExport.App.Services.Data.LayoutFieldsMap;

namespace VehicleExport.Web.Controllers.Data.LayoutFieldsMap
{
    [Authorize]
    public class LayoutFieldsMapController : EntityWriteController<LayoutFieldMap, IEntityWriteService<LayoutFieldMap, int>, int>
    {
        private LayoutFieldsMapService _layoutFieldsMapService;
        public LayoutFieldsMapController(IConfiguration configuration, IEntityWriteService<LayoutFieldMap, int> service, LayoutFieldsMapService layoutFieldsMapService) : base(configuration, service)
        {
            _layoutFieldsMapService = layoutFieldsMapService;
        }


        [HttpPut("saveLayoutFieldMap/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        public new async Task<ActionResult> Update(int id, [FromBody] ExpandoObject dtoModel, string context = null)
        {
            id = GetOneId(id);

            LayoutFieldMap dataModel = ConvertToDataModel(dtoModel, context);

            dataModel = await _layoutFieldsMapService.UpdateLayoutField(HttpContext.User, dataModel, null);

            object returnValue = ConvertToDTO(dataModel, "", context);

            return Ok(returnValue);
        }
    }
}
