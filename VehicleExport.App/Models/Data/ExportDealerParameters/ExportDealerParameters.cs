﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Exports;
using VehicleExport.App.Models.Data.LayoutFields;
using VehicleExport.App.Models.Data.ExportDealers;

namespace VehicleExport.App.Models.Data.ExportDealerParameters
{
    public class ExportDealerParameter : IEntity
    {

        [Timestamp]
        [ConcurrencyCheck]
        public byte[] ConcurrencyTimestamp { get; set; }

        [NotMapped]
        public string ConcurrencyCheck
        {
            get { return ConcurrencyTimestamp == null ? null : Convert.ToBase64String(ConcurrencyTimestamp); }
            set { ConcurrencyTimestamp = value == null ? null : Convert.FromBase64String(value); }
        }

        [Required]
        public int ExportId { get; set; }

        [Required]
        public int DealerId { get; set; }

        [Required]
        public int LayoutFieldId { get; set; }

        [Required]
        public string ParameterValue { get; set; }

        [Required]
        public DateTime dtmCreated { get; set; }

        // External References. Use "Virtual" to enable lazy loading
        public virtual LayoutField LayoutField { get; set; }
        public virtual ExportDealer ExportDealer { get; set; }
    }
}