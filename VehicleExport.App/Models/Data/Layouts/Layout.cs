using VehicleExport.App.Models.Data.Accounts;
using VehicleExport.App.Models.Data.Dealers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleExport.App.Models.Data.Exports;

namespace VehicleExport.App.Models.Data.Layouts
{
    public  class Layout : IEntity, IHasId<int>, ILoggableName
    {
        public int GetId() => LayoutId;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LayoutId { get; set; }

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
        public string LoggableName { get { return LayoutId.ToString(); } }

        public List<Export> Exports { get; set; }
    }
}
