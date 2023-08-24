using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace VehicleExport.App.Models.Data.Exports
{
    public class ExportTracking : IEntity, IHasId<int>, ILoggableName
    {
        public int GetId() => ExportTrackingId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExportTrackingId { get; set; }

        [Timestamp]
        [ConcurrencyCheck]
        public byte[] ConcurrencyTimestamp { get; set; }

        [NotMapped]
        public string ConcurrencyCheck
        {
            get { return ConcurrencyTimestamp == null ? null : Convert.ToBase64String(ConcurrencyTimestamp); }
            set { ConcurrencyTimestamp = value == null ? null : Convert.FromBase64String(value); }
        }

        [NotMapped]
        public string LoggableName { get { return ExportTrackingId.ToString(); } }

        [Required]
        public int ExportId { get; set; }

        [Required]
        public DateTime ExportDate { get; set; }

        [Required]
        public int VehicleCount { get; set; }


        // External References. Use "Virtual" to enable lazy loading
        public virtual List<ExportTrackingDealer> ExportTrackingDealer { get; set; }


    }
}

