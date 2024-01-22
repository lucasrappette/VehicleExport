using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace VehicleExport.App.Models.Data.LayoutFieldsMap.Validators
{
    public class LayoutFieldsMapValidator : AbstractValidator<LayoutFieldMap>
    {
        public LayoutFieldsMapValidator()
        {
            RuleFor(x => x.FieldOrder > 0);
        }
    }
}
