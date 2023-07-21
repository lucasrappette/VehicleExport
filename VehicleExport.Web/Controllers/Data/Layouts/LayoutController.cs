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

namespace VehicleExport.Web.Controllers.Data.Layouts
{
    [Authorize]
    public class LayoutController : EntityWriteController<Layout, IEntityWriteService<Layout, int>, int>
    {
        public LayoutController(IConfiguration configuration, IEntityWriteService<Layout, int> service) : base(configuration, service)
        {
        }
    }
}
