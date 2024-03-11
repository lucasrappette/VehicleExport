using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleExport.App.Models.Data.Layouts;
using VehicleExport.App.Models.Data.LayoutFields;

namespace VehicleExport.App.Models.Data.LayoutFieldsMap
{
    public class LayoutFieldMap : IEntity, IHasId<int>, ILoggableName, IEquatable<LayoutFieldMap>
    {
        public int GetId() => LayoutFieldsMapId;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LayoutFieldsMapId { get; set; }

        [Required]
        public int LayoutId { get; set; }

        public int LayoutFieldId { get; set; }

        [MaxLength(25)]
        public string HeaderLabel { get; set; }

        public short FieldOrder { get; set; }

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
        public string ReplacementOption { get; set; }
        [NotMapped]
        public short? NewFieldOrder { get; set; }
        [NotMapped]
        public string LoggableName { get { return LayoutFieldsMapId.ToString(); } }

        // External References. Use "Virtual" to enable lazy loading
        public virtual Layout Layout { get; set; }
        public virtual LayoutField LayoutField { get; set; }

        public bool Equals(LayoutFieldMap other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;
            return other.FieldOrder == this.FieldOrder &&
                other.HeaderLabel == this.HeaderLabel &&
                other.LayoutFieldsMapId == this.LayoutFieldsMapId &&
                other.LayoutFieldId == this.LayoutFieldId &&
                other.LayoutId == this.LayoutId;
        }
    }
}

