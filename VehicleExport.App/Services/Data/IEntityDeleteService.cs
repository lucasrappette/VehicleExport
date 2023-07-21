using VehicleExport.App.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace VehicleExport.App.Services.Data
{
    public interface IEntityDeleteService<TDataModel, TIdType> : IEntityWriteService<TDataModel, TIdType>
        where TDataModel : IEntity
    {
        Task<TDataModel> Delete(ClaimsPrincipal user, TIdType id);
    }
}
