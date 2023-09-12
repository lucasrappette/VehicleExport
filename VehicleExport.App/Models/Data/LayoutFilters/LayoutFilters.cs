using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using VehicleExport.App.Models.Data.Layouts;

namespace VehicleExport.App.Models.Data.LayoutFilters
{
    public class LayoutFilter : IEntity, IHasId<int>, ILoggableName
    {
        public int GetId() => LayoutId;

        [Key]
         public int LayoutId { get; set; }

        [NotMapped]
        public string LoggableName { get { return LayoutId.ToString(); } }

        public string? MakesList { get; set; }

        public bool CertifiedOnly { get; set; }

        public bool NewVehicles { get; set; }

        public bool UsedVehicles { get; set; }

        public string? WarrantiesList { get; set; }

        public string? ProductsList { get; set; }

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
        public virtual Layout Layout { get; set; }
    }
}
