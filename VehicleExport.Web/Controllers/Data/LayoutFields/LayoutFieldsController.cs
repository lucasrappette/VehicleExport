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
using VehicleExport.App.Models.Data.LayoutFields;

namespace VehicleExport.Web.Controllers.Data.LayoutFields
{
    [Authorize]
    public class LayoutFieldsController : EntityWriteController<LayoutField, IEntityWriteService<LayoutField, int>, int>
    {
        public LayoutFieldsController(IConfiguration configuration, IEntityWriteService<LayoutField, int> service) : base(configuration, service)
        {
        }
    }
}
