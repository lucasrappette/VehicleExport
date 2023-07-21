using FluentValidation;
using VehicleExport.App.Models.Data.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleExport.App.Models.Data.Donors.Validators
{
    public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
    {
        public ApplicationUserValidator()
        {
        }
    }
}
