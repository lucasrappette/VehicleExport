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
using VehicleExport.App.Models.Data.Layouts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using VehicleExport.Web.Middleware.Exceptions;
using VehicleExport.App.Services.Data.Layouts;

namespace VehicleExport.Web.Controllers.Data.Layouts
{
    [Authorize]
    public class LayoutController : EntityWriteController<Layout, IEntityWriteService<Layout, int>, int>
    {
        private LayoutService _layoutService;
        public LayoutController(LayoutService layoutService, IConfiguration configuration, IEntityWriteService<Layout, int> service) : base(configuration, service)
        {
            _layoutService = layoutService;
        }

        [HttpPost("cloneLayout")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CloneLayout([FromBody] ExpandoObject dtoModel, string context = null)
        {
            Layout dataModel = ConvertToDataModel(dtoModel, context);
            dataModel = await _layoutService.CloneLayout(HttpContext.User, dataModel);
            object returnValue = ConvertToDTO(dataModel, "", context);

            return CreatedAtAction(nameof(GetOne), new { id = dataModel.GetId() }, returnValue);
        }
    }
}
