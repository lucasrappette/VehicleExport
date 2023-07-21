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

namespace VehicleExport.Web.Controllers.Data.Destinations
{
    [Authorize]
    public class DestinationController : EntityWriteController<Destination, IEntityWriteService<Destination, int>, int>
    {
        public DestinationController(IConfiguration configuration, IEntityWriteService<Destination, int> service) : base(configuration, service)
        {
        }
    }
}
