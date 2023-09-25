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
using VehicleExport.App.Models.Data.Destinations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using VehicleExport.Web.Middleware.Exceptions;
using VehicleExport.Core.Models;
using System.Runtime.InteropServices;
using VehicleExport.App.Services.Data.Destinations;
using System.Net.Mime;

namespace VehicleExport.Web.Controllers.Data.Destinations
{
    [Authorize]
    public class DestinationController : EntityWriteController<Destination, IEntityWriteService<Destination, int>, int>
    {
        private DestinationService _destinationService { get; set; }
        public DestinationController(IConfiguration configuration, IEntityWriteService<Destination, int> service, DestinationService destinationService) : base(configuration, service)
        {
            _destinationService = destinationService;
        }

        /// <summary>
        /// Creates a new item
        /// </summary>
        /// <param name="dtoModel">The item to create</param>
        /// <returns></returns>
        /// <response code="400">Item validation failed</response>
        /// <response code="403">User does not have permission to create item</response>
        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        public new async Task<ActionResult> Create(IFormCollection FormData)
        {
            ExpandoObject dtoModel = new ExpandoObject();
            foreach (var valuePair in FormData)
            {
                if (valuePair.Value[0] != null && valuePair.Value[0].ToString() != "null")
                    dtoModel.TryAdd(valuePair.Key, valuePair.Value[0]);
            }
            foreach (var fileValuePair in FormData.Files)
            {
                dtoModel.TryAdd(fileValuePair.Name, fileValuePair);
            }
            Destination dataModel = ConvertToDataModel(dtoModel, ModelContexts.WebApiElevated);

            dataModel = await _writeService.Create(HttpContext.User, dataModel);
            object returnValue = ConvertToDTO(dataModel, "", ModelContexts.WebApiElevated);

            return CreatedAtAction(nameof(GetOne), new { id = dataModel.GetId() }, returnValue);
        }

        /// <summary>
        /// Updates an item
        /// </summary>
        /// <param name="dtoModel">The new value for the item</param>
        /// <returns>Returns the item (with an updated timestamp)</returns>
        /// <response code="400">Item validation failed</response>
        /// <response code="403">User does not have permission to update item</response>
        /// <response code="409">Concurrency conflict. The item sent in the request is no longer the most recent version of the item</response>
        [HttpPut]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(IFormCollection FormData)
        {
            ExpandoObject dtoModel = new ExpandoObject();
            foreach(var valuePair in FormData)
            {
                if (valuePair.Value[0] != null && valuePair.Value[0].ToString() != "null")
                    dtoModel.TryAdd(valuePair.Key, valuePair.Value[0]);
            }
            foreach(var fileValuePair in FormData.Files)
            {
                dtoModel.TryAdd(fileValuePair.Name, fileValuePair);
            }
            Destination dataModel = ConvertToDataModel(dtoModel, ModelContexts.WebApiElevated);

            dataModel = await _writeService.Update(HttpContext.User, dataModel);

            object returnValue = ConvertToDTO(dataModel, "", ModelContexts.WebApiElevated);

            return Ok(true);
        }

        [HttpGet("downloadFile/{sshkeyFileName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [AllowAnonymous]
        public async Task<ActionResult> Download(string sshkeyFileName)
        {
            var file = await _destinationService.DownloadFile(User, sshkeyFileName);
            return File(file, "application/octet-stream");
        }

    }
}
