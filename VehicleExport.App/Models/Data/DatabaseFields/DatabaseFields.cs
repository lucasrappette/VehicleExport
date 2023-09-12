using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleExport.App.Models.Data.DatabaseFields
{
    public  class DatabaseField : IEntity, IHasId<int>, ILoggableName
    {
        public int GetId() => DatabaseFieldId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DatabaseFieldId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(75)]
        [Required]
        public string FieldLabel { get; set; }

        public string? SqlText { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }

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

        [NotMapped]
        public string LoggableName { get { return DatabaseFieldId.ToString(); } }

        // External References

    }
}
