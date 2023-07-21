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
    public class ApplicationUserController : EntityWriteController<ApplicationUser, IEntityWriteService<ApplicationUser, Guid>, Guid>
    {
        public ApplicationUserController(IConfiguration configuration, IEntityWriteService<ApplicationUser, Guid> service) : base(configuration, service)
        {
        }
    }
}
