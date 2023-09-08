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
using VehicleExport.App.Models.Data.MinorEntity;

namespace VehicleExport.Web.Controllers.Data.MinorEntity
{
    [Authorize]
    public class OutputFormatTypeController : EntityReadController<OutputFormatType, IEntityReadService<OutputFormatType, short>, short>
    {
        public OutputFormatTypeController(IConfiguration configuration, IEntityReadService<OutputFormatType, short> service) : base(configuration, service)
        {
        }
    }
}
