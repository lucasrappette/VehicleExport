using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data;

namespace VehicleExport.App.Models.Data
{
    public class Warranties : IEntity, IHasId<int>
    {
        public int GetId() => this.WarrantyId;

        public int WarrantyId { get; set; }
        public string WarrantyName { get; set; }


    }
}
