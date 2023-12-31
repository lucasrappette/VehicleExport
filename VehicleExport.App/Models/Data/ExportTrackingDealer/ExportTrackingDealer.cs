﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleExport.App.Models.Data.Exports
{
    public class ExportTrackingDealer : IEntity, IHasId<int>
    {
        public int GetId() => ExportTrackingDealerId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExportTrackingDealerId { get; set; }

        public int ExportTrackingId { get; set; }

        [Required]
        public int DealerId { get; set; }

        [Required]
        public int VehicleCount { get; set; }

        [Required]
        public short PhotoCount { get; set; }

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


    }
}

