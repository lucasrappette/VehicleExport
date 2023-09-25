using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data;
using VehicleExport.App.Services.Data;
using VehicleExport.App.Utilities.Serialization;
using VehicleExport.Core.Models;
using VehicleExport.Web.Controllers.Generics.Requests;
using VehicleExport.Web.Filters.Support;
using VehicleExport.Web.Middleware.Exceptions;

namespace VehicleExport.Web.Controllers.Generics
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityProcedureController<TDataModel, TService> : ControllerBase
        where TDataModel : class, IEntity
        where TService : IEntityProcedureService<TDataModel>
    {
        protected readonly IConfiguration _configuration;
        protected readonly TService _executeService;

        public EntityProcedureController(IConfiguration configuration, TService executeService)
        {
            _configuration = configuration;
            _executeService = executeService;
        }

        /// <summary>
        /// Returns all items
        /// </summary>
        /// <param name="filter">The filters to apply to the results</param>
        /// <param name="maxCount">The highest number that will be returned for X-Total-Count. By default, there's a limit applied and the full limit isn't returned; if you pass -1 you'll get the full number of results available in X-Total-Count</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [SwaggerResponseHeader(StatusCodes.Status200OK, "X-Total-Count", "int", "Returns the total number of available items (not to exceed X-Total-Count-Max)")]
        [SwaggerResponseHeader(StatusCodes.Status200OK, "X-Total-Count-Max", "int", "Returns the highest total number that could be returned. If this equals X-Total-Count, then there are probably more results available than the number returned in X-Total-Count")]
        public async Task<ActionResult<IEnumerable<dynamic>>> ExecuteStoredProcedureGetAll(ExecuteStoredProcRequest request)
        {
            List<TDataModel> dataModelItems = await _executeService.ExecuteStoredProcedureGetAll(HttpContext.User, request.ProcedureName, request.Filter, request.Includes, request.ProcArguments, null);

            List<dynamic> dtoModelItems = dataModelItems
                .Select(d => ConvertToDTO(d, request.Includes, request.Context))
                .ToList();

            Response.Headers.Add("X-Total-Count", dtoModelItems.Count.ToString());
            Response.Headers.Add("X-Total-Count-Max", dtoModelItems.Count.ToString());

            return Ok(dtoModelItems);
        }

        /// <summary>
        /// Converts a data model to a DTO
        /// </summary>
        /// <param name="dataModel"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        protected virtual dynamic ConvertToDTO(TDataModel dataModel, string includes = "", string context = null)
        {
            if (context == null)
                context = GetDefaultModelContext();

            return DataModelConverter.ConvertToDTO(GetModelContext(context), dataModel, new ConvertToDTOOptions(includes));
        }

        /// <summary>
        /// Returns the default model context. If different users have different default model contexts, override this to specify the correct context
        /// </summary>
        /// <returns></returns>
        protected virtual string GetDefaultModelContext()
        {
            return ModelContexts.WebApi;
        }

        /// <summary>
        /// Ensures the current user can use the specified model context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual string GetModelContext(string context)
        {
            if (context == null)
                context = GetDefaultModelContext();

            return context;
        }
    }
}
