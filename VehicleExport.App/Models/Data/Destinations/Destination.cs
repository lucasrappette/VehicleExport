using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleExport.App.Models.Data.Exports;

namespace VehicleExport.App.Models.Data.Destinations
{
    public class Destination : IEntity, IHasId<int>, ILoggableName
    {
        public int GetId() => DestinationId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DestinationId { get; set; }

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
        public string LoggableName { get { return DestinationId.ToString(); } }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string FtpHost { get; set; }

        [MaxLength(50)]
        [Required]
        public string FtpUsername { get; set; }

        [MaxLength(50)]
        [Required]
        public string FtpPassword { get; set; }

        [MaxLength(50)]
        public string? FtpRemoteDir { get; set; }

        [Required]
        public short ProtocolTypeId { get; set; }

        [MaxLength(250)]
        public string SSHKeyFilePath { get; set; }

        [Required]
        public short OutputFormatTypeId { get; set; }

        public bool UseQuotedFields { get; set; }

        public bool IncludeHeaders { get; set; }

        [MaxLength(50)]
        [Required]
        public string OutputFileName { get; set; }

        public bool ZipOutputFile { get; set; }

        public bool OneFilePerDealer { get; set; }

        public bool SendPhotosInZip { get; set; }

        [Required]
        public DateTime dtmCreated { get; set; }

        public DateTime dtmLastChanged { get; set; }

        // External References
        public List<Export> Exports { get; set; }
    }
}
