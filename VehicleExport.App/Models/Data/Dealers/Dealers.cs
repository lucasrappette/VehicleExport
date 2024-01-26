using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data;

namespace VehicleExport.App.Models.Data
{
    public class Dealers : IEntity, IHasId<int>
    {
        public int GetId() => this.DealerId;

        public int DealerId { get; set; }
        public string DealerName { get; set; }


    }
}
