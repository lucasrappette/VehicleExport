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
    public class EncryptionTypeController : EntityReadController<EncryptionType, IEntityReadService<EncryptionType, short>, short>
    {
        public EncryptionTypeController(IConfiguration configuration, IEntityReadService<EncryptionType, short> service) : base(configuration, service)
        {
        }
    }
}
