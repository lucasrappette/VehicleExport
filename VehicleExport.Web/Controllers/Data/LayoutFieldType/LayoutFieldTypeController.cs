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
    public class LayoutFieldTypeController : EntityReadController<LayoutFieldType, IEntityReadService<LayoutFieldType, short>, short>
    {
        public LayoutFieldTypeController(IConfiguration configuration, IEntityReadService<LayoutFieldType, short> service) : base(configuration, service)
        {
        }
    }
}
