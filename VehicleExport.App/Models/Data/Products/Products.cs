using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data;

namespace VehicleExport.App.Models.Data
{
    public class Products : IEntity, IHasId<int>
    {
        public int GetId() => this.ProductId;

        public int ProductId { get; set; }
        public string ProductName { get; set; }


    }
}
