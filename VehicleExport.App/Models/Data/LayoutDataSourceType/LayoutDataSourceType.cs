using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Exports;
using VehicleExport.App.Models.Data.Layouts;

namespace VehicleExport.App.Models.Data.MinorEntity
{
    public class LayoutDataSourceType : IEntity, IHasId<short>
    {
        public short GetId() => LayoutDataSourceTypeId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short LayoutDataSourceTypeId { get; set; }

        [Required]
        public string Description { get; set; }
        public List<Layout> Layouts { get; set; }

    }
}
