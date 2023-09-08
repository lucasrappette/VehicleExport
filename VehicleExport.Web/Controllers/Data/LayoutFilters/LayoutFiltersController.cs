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
using VehicleExport.App.Models.Data.LayoutFilters;

namespace VehicleExport.Web.Controllers.Data.LayoutFilters
{
    [Authorize]
    public class LayoutFilterController : EntityWriteController<LayoutFilter, IEntityWriteService<LayoutFilter, int>, int>
    {
        public LayoutFilterController(IConfiguration configuration, IEntityWriteService<LayoutFilter, int> service) : base(configuration, service)
        {
        }
    }
}
