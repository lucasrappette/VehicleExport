using AutoMapper;
using Microsoft.Extensions.Configuration;
using VehicleExport.App.Models.Data.Accounts;
using VehicleExport.DTO.Accounts;
using VehicleExport.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleExport.App.Services.Data;

namespace VehicleExport.Web.Controllers.Data.Accounts
{
    public class ApplicationRoleController : EntityWriteController<ApplicationRole, IEntityWriteService<ApplicationRole, Guid>, Guid>
    {
        public ApplicationRoleController(IConfiguration configuration, IEntityWriteService<ApplicationRole, Guid> service) : base(configuration, service)
        {
        }
    }
}
