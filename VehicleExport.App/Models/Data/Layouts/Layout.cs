using VehicleExport.App.Models.Data.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Exports;
using VehicleExport.App.Models.Data.LayoutFilters;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Data;

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

        public virtual LayoutFilter LayoutFilter  { get; set; }
}
}
