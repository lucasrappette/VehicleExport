﻿using AutoMapper;
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
    public class TransferModeTypeController : EntityReadController<TransferModeType, IEntityReadService<TransferModeType, short>, short>
    {
        public TransferModeTypeController(IConfiguration configuration, IEntityReadService<TransferModeType, short> service) : base(configuration, service)
        {
        }
    }
}
