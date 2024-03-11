using FluentValidation;
using VehicleExport.App.DAL;
using VehicleExport.App.Models.Data.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Donors;
using VehicleExport.App.Models;
using System.Collections.Generic;
using VehicleExport.Core.Models;
using VehicleExport.App.Services.WorkItems;
using VehicleExport.App.Models.Data.LayoutFields;
using VehicleExport.App.Models.Data.LayoutFieldsMap;
using Microsoft.EntityFrameworkCore;
using VehicleExport.App.Exceptions;
using VehicleExport.App.Models.Data;
using VehicleExport.App.Utilities;

namespace VehicleExport.App.Services.Data.LayoutFieldsMap
{
    public class LayoutFieldsMapService : EntityWriteService<LayoutFieldMap, int>
    {
        public LayoutFieldsMapService(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IValidator<LayoutFieldMap> validator, ILogger<LayoutFieldsMapService> logger) : base(dbContext, configuration, userManager, validator, logger)
        {
           
        }

        protected override async Task<IQueryable<LayoutFieldMap>> ApplyIdFilter(IQueryable<LayoutFieldMap> queryable, int id)
        {
            return queryable.Where(x => x.LayoutFieldsMapId == id);
        }

        protected override async Task OnCreating(ClaimsPrincipal user, LayoutFieldMap dataModel, Dictionary<string, object> extraData) 
        {
            //Find current max field order, set field order to that + 1.
            var layoutFieldsInMap = await GetAll(user, 0, 100000, "fieldOrder", null, null, true, queryable =>
            {
                return queryable
                    .Where(x => x.LayoutId == dataModel.LayoutId);
            });
            if (layoutFieldsInMap.Count > 0)
            {
                var maxFieldOrder = layoutFieldsInMap.Max(x => x.FieldOrder);
                dataModel.FieldOrder = (short)(maxFieldOrder + 1);
            }
            else
            {
                dataModel.FieldOrder = 1;
            }
        }

        public async Task<LayoutFieldMap> UpdateLayoutField(ClaimsPrincipal user, LayoutFieldMap dataModel, Dictionary<string, object> extraData)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                var applicationUser = await GetApplicationUser(user);

                dataModel = await StripNavigationProperties(dataModel);

                if (!await CanUpdate(applicationUser, dataModel, extraData))
                    throw new ForbiddenException();

                var oldDataModel = await GetItemById(applicationUser, dataModel.GetId(), null);
                _dbContext.Entry(oldDataModel).State = EntityState.Detached;

                /* Begin custom code */
                if (dataModel.ReplacementOption != null && (dataModel.NewFieldOrder.HasValue && dataModel.NewFieldOrder.Value > 0))
                {
                    var fieldMappings = await GetAll(user, 0, 1000000, "fieldOrder", null, null, false, queryable =>
                    {
                        return queryable.Where(x => x.LayoutId == dataModel.LayoutId);
                    });
                    if(dataModel.ReplacementOption.Equals("insert", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var fieldMappingsToUpdate = fieldMappings.OrderBy(x => x.FieldOrder).ToList();
                        var newRefDataModel = new LayoutFieldMap
                        {
                            LayoutFieldId = dataModel.LayoutFieldId,
                            LayoutId = dataModel.LayoutId,
                            LayoutFieldsMapId = dataModel.LayoutFieldsMapId,
                            HeaderLabel = dataModel.HeaderLabel?.ToString(),
                            FieldOrder = dataModel.NewFieldOrder.Value,
                            NewFieldOrder = dataModel.NewFieldOrder.Value,
                            ReplacementOption = dataModel.ReplacementOption,
                            ConcurrencyTimestamp = dataModel.ConcurrencyTimestamp.ToArray(),
                        };
                        if (fieldMappingsToUpdate.FindIndex(x => x.Equals(dataModel)) >= dataModel.NewFieldOrder)
                        {
                            //We're ascending the list, so remove 1 to be able to insert into list correctly. I am sure there is a simpler way
                            fieldMappingsToUpdate.Insert(dataModel.NewFieldOrder.Value - 1, newRefDataModel);

                        }
                        else
                        {
                            //Descending the list
                            fieldMappingsToUpdate.Insert(dataModel.NewFieldOrder.Value, newRefDataModel);
                        }
                        //Removes old ref, effectively leaving an ordered list after the insert. We let the List ordering do the work
                        fieldMappingsToUpdate.Remove(dataModel);
                        for(int i = 0; i < fieldMappingsToUpdate.Count; i++)
                        {
                            var fieldMapping = fieldMappingsToUpdate[i];
                            fieldMapping.FieldOrder = (short)(i + 1);
                            await Update(user, fieldMapping);
                        }
                        //Update all field mappings and commit;
                    }
                    else if(dataModel.ReplacementOption.Equals("replace", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var fieldMappingToReplace = fieldMappings.Where(x => x.FieldOrder == dataModel.NewFieldOrder.Value).First();
                        fieldMappingToReplace.FieldOrder = dataModel.FieldOrder;
                        await Update(user, fieldMappingToReplace);
                        dataModel.FieldOrder = dataModel.NewFieldOrder.Value;
                        await Update(user, dataModel);
                    }
                }
                /*End Custom Code */
                await transaction.CommitAsync();
                return dataModel;
            }
        }

        protected override List<string> ReadRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager, ApplicationRoleNames.ProjectViewer };
        protected override List<string> WriteRoles => new List<string> { ApplicationRoleNames.SuperAdmin, ApplicationRoleNames.ProjectManager };
    }
}
