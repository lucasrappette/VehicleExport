using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Exports;
using VehicleExport.App.Models.Data.Destinations;

namespace VehicleExport.App.Models.Data.MinorEntity
{
    public class EncryptionProtocolType : IEntity, IHasId<short>
    {
        public short GetId() => EncryptionProtocolTypeId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short EncryptionProtocolTypeId { get; set; }

        [Required]
        public string Description { get; set; }

        public List<Destination> Destinations { get; set; }

    }
}
