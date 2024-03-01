using VehicleExport.App.Models.Data.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Exports;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Data;
using VehicleExport.App.Models.Data.MinorEntity;
using VehicleExport.App.Models.Data.LayoutFieldsMap;

namespace VehicleExport.App.Models.Data.Layouts
{
    public  class Layout : IEntity, IHasId<int>, ILoggableName
    {
        public int GetId() => LayoutId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LayoutId { get; set; }

        [NotMapped]
        public string LoggableName { get { return LayoutId.ToString(); } }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string StoredProcedureName { get; set; }

        [Required]
        public short LayoutDataSourceTypeId { get; set; }

        public string MakesList { get; set; }

        public bool? CertifiedOnly { get; set; }

        public bool? NewVehicles { get; set; }

        public bool? UsedVehicles { get; set; }

        public string WarrantiesList { get; set; }

        public string ProductsList { get; set; }

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

        // External References
        public List<Export> Exports { get; set; }

        public virtual LayoutDataSourceType LayoutDataSourceType { get; set; }
        public virtual List<LayoutFieldMap> LayoutFieldMappings { get; set; }
    }
}
