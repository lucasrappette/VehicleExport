using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data;

namespace VehicleExport.App.Models.Data
{
    public class Makes : IEntity, IHasId<string>
    {
        public string GetId() => this.Make;

        public string Make { get; set; }


    }
}
