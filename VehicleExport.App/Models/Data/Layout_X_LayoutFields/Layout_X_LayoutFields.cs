using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleExport.App.Models.Data.Layout_X_LayoutFields
{
    public class Layout_X_LayoutField : IEntity
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

        public int? LayoutFieldId { get; set; }

        [MaxLength(25)]
        public string PlaceholderLabel { get; set; }

        public short FieldOrder { get; set; }

        // External References

    }
}

