using AutoMapper;
using VehicleExport.Web.Middleware.Exceptions;
using VehicleExport.App.Models.Data.Content;
using VehicleExport.App.Models.Service.Content;
using VehicleExport.App;
using VehicleExport.App.Services.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleExport.App.Services.Data.Content;
using VehicleExport.App.Utilities.Serialization;
using VehicleExport.Core.Models;

namespace VehicleExport.Web.Controllers.Data.Content
{
    [Authorize]
    public class ContentBlockController : EntityWriteController<ContentBlock, ContentBlockService, Guid>
    {
        public ContentBlockController(IConfiguration configuration, ContentBlockService service) : base(configuration, service)
        {
        }

        /// <summary>
        /// Gets a content block by its slug
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("slug/{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> GetBySlug(string slug)
        {
            var contentData = await _writeService.GetContentData(slug, new Dictionary<string, string>(), false);
            var returnValue = DataModelConverter.ConvertToDTO(ModelContexts.WebApi, contentData, new ConvertToDTOOptions());

            return Ok(returnValue);
        }
    }
}
