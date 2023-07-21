using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleExport.App.Models.Service.WorkItems.Echo;
using VehicleExport.App.Services.WorkItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleExport.Web.Controllers.WorkItems
{
    [Authorize]
    public class EchoWorkItemController : WorkItemController<EchoWorkItem>
    {
        public EchoWorkItemController(ISecureWorkItemService<EchoWorkItem> secureWorkItemService) : base(secureWorkItemService)
        {
        }
    }
}
