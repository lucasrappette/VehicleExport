using VehicleExport.App.Models.Data.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Layouts;
using VehicleExport.App.Models.Data.Destinations;
using VehicleExport.App.Models.Data.ExportDealers;

namespace VehicleExport.App.Models.Data.Exports
{
    public class Export : IEntity, IHasId<int>, ILoggableName
    {
        public int GetId() => ExportId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExportId { get; set; }

        [NotMapped]
        public string LoggableName { get { return ExportId.ToString(); } }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int LayoutId { get; set; }

        [Required]
        public int DestinationId { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? RunTimeOne { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? RunTimeTwo { get; set; }

        public DateTime dtmCreated { get; set; }

        public DateTime dtmLastChanged { get; set; }

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
        public virtual Layout Layout { get; set; }
        public virtual Destination Destination { get; set; }
        public virtual List<ExportTracking> ExportTracking { get; set; }
        public virtual List<ExportDealer> ExportDealer { get; set; }
    }
}

