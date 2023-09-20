using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleExport.App.Models.Data.Exports;
using System.Net.Sockets;
using VehicleExport.App.Models.Data.MinorEntity;
using Microsoft.AspNetCore.Http;

namespace VehicleExport.App.Models.Data.Destinations
{
    public class Destination : IEntity, IHasId<int>, ILoggableName
    {
        public int GetId() => DestinationId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DestinationId { get; set; }

        [NotMapped]
        public string LoggableName { get { return DestinationId.ToString(); } }

        [NotMapped]
        public IFormFile SshFile { get; set; }

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
        public string FtpRemoteDir { get; set; }

        [Required]
        public short ProtocolTypeId { get; set; }
        [Required]
        public short EncryptionTypeId { get; set; }
        [Required]
        public short EncryptionProtocolTypeId { get; set; }

        [MaxLength(250)]
        public string SSHKeyFileName { get; set; }

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

        public string SshFilePassword { get; set; }
        public string SshKeyFileChecksum { get; set; }

        [Timestamp]
        [ConcurrencyCheck]
        public byte[] ConcurrencyTimestamp { get; set; }

        [NotMapped]
        public string ConcurrencyCheck
        {
            get { return ConcurrencyTimestamp == null ? null : Convert.ToBase64String(ConcurrencyTimestamp); }
            set { ConcurrencyTimestamp = value == null ? null : Convert.FromBase64String(value); }
        }

        // External References
        public List<Export> Exports { get; set; }
        public VehicleExport.App.Models.Data.MinorEntity.ProtocolType ProtocolType { get; set; }
        public OutputFormatType OutputFormatType { get; set; }
        public EncryptionType EncryptionType { get; set; }
        public EncryptionProtocolType EncryptionProtocolType { get; set; }
    }
}
