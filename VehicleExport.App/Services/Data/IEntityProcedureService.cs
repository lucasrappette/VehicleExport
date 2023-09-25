using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data;
using VehicleExport.App.Models.Data.Generics;

namespace VehicleExport.App.Services.Data
{
    public interface IEntityProcedureService<TDataModel>
        where TDataModel : IEntity
    {
        Task<List<TDataModel>> ExecuteStoredProcedureGetAll(ClaimsPrincipal user, string procedureName, string filter, string includes, IList<SqlProcArgument> procArguments, Func<IQueryable<TDataModel>, IQueryable<TDataModel>> filterFunc, Func<IQueryable<TDataModel>, IQueryable<TDataModel>> includesFunc = null);
    }
}
