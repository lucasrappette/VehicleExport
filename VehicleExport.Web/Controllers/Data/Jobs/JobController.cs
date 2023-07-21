using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using VehicleExport.App.Models.Data.Jobs;
using VehicleExport.App.Services.Data;
using System;

namespace VehicleExport.Web.Controllers.Data.Jobs
{
    [Authorize]
    public class JobController : EntityWriteController<Job, IEntityWriteService<Job, Guid>, Guid>
    {
        public JobController(IConfiguration configuration, IEntityWriteService<Job, Guid> service) : base(configuration, service)
        {
        }
    }
}
