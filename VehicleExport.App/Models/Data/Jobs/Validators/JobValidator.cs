﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExport.App.Models.Data.Jobs.Validators
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
        }
    }
}
