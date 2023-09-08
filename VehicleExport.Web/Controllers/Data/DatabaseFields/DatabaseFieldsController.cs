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
using VehicleExport.App.Models.Data.DatabaseFields;

namespace VehicleExport.Web.Controllers.Data.DatabaseFields
{
    [Authorize]
    public class DatabaseFieldsController : EntityWriteController<DatabaseField, IEntityWriteService<DatabaseField, int>, int>
    {
        public DatabaseFieldsController(IConfiguration configuration, IEntityWriteService<DatabaseField, int> service) : base(configuration, service)
        {
        }
    }
}
