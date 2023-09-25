using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Exports;
using VehicleExport.App.Models.Data.Layouts;
using VehicleExport.App.Models.Data.LayoutFields;

namespace VehicleExport.App.Models.Data.MinorEntity
{
    public class LayoutFieldType : IEntity, IHasId<short>
    {
        public short GetId() => LayoutFieldTypeId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short LayoutFieldTypeId { get; set; }

        [Required]
        public string Description { get; set; }
        public List<LayoutField> LayoutFields { get; set; }

    }
}
