using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Exports;

namespace VehicleExport.App.Models.Data.MinorEntity
{
    public class OutputFormatType : IEntity, IHasId<short>
    {
        public short GetId() => OutputFormatTypeId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short OutputFormatTypeId { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
