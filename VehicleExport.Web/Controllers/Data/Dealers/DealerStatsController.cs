﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using VehicleExport.App.Models.Data.Dealers;
using VehicleExport.App.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleExport.Web.Controllers.Data.Dealers
{
    [Authorize]
    public class DealerStatsController : EntityReadController<DealerStats, IEntityReadService<DealerStats, Guid>, Guid>
    {
        public DealerStatsController(IConfiguration configuration, IEntityWriteService<DealerStats, Guid> service) : base(configuration, service)
        {
        }
    }
}
