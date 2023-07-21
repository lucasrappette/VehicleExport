using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VehicleExport.App.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleExport.Web.Controllers
{
    public class DocumentationController : Controller
    {
        private readonly IConfiguration _configuration;

        public DocumentationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            if (!_configuration.GetValue<bool>("AllowDocumentationController", false))
                throw new Exception("Documentation Controller is disabled");

            return Content(ConventionUtilities.GetSummary(), "text/html");
        }
    }
}
