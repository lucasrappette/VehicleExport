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
using VehicleExport.App.Models.Data.Dealers;

namespace VehicleExport.Web.Controllers.Data.Dealers
{
    [Authorize]
    public class DealerController : EntityWriteController<Dealer, IEntityWriteService<Dealer, Guid>, Guid>
    {
        public DealerController(IConfiguration configuration, IEntityWriteService<Dealer, Guid> service) : base(configuration, service)
        {
        }
    }
}
