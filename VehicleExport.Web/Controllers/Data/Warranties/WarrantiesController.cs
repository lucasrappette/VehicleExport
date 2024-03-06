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
using VehicleExport.App.Models.Data;
using VehicleExport.Core.Models;
using VehicleExport.Web.Controllers;

namespace VehicleExport.Web.Controllers.Data
{
    [Authorize]
    public class WarrantiesController : EntityReadController<Warranties, IEntityReadService<Warranties, int>, int>
    {
        public WarrantiesController(IConfiguration configuration, IEntityReadService<Warranties, int> service) : base(configuration, service)
        {
        }
    }
}
