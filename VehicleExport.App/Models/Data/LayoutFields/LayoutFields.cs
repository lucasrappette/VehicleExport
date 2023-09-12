using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using VehicleExport.App.Models.Data.Destinations;
using System.Collections.Generic;
using VehicleExport.App.Models.Data.Exports;
using VehicleExport.App.Models.Data.DatabaseFields;

namespace VehicleExport.App.Models.Data.LayoutFields
{
    public class LayoutField : IEntity, IHasId<int>, ILoggableName
    {
        public int GetId() => LayoutFieldId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LayoutFieldId { get; set; }

        [NotMapped]
        public string LoggableName { get { return LayoutFieldId.ToString(); } }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int LayoutId { get; set; }

        [Required]
        public Int16 LayoutFieldTypeId { get; set; }

        public int? DatabaseFieldId { get; set; }

        [MaxLength(50)]
        public string? Parameter { get; set; }

        [Required]
        public DateTime dtmCreated { get; set; }

        [Timestamp]
        [ConcurrencyCheck]
        public byte[] ConcurrencyTimestamp { get; set; }

        [NotMapped]
        public string ConcurrencyCheck
        {
            get { return ConcurrencyTimestamp == null ? null : Convert.ToBase64String(ConcurrencyTimestamp); }
            set { ConcurrencyTimestamp = value == null ? null : Convert.FromBase64String(value); }
        }

        // External References. Use "Virtual" to enable lazy loading
        public virtual DatabaseField DatabaseField { get; set; }

    }
}

