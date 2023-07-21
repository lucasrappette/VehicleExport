using FluentValidation;
using VehicleExport.App.Models.Data.Exports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExport.App.Models.Data.Exports.Validators
{
    public class ExportValidator : AbstractValidator<Export>
    {
        public ExportValidator()
        {

        }
    }
}
