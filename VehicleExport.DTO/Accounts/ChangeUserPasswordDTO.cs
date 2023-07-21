using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExport.DTO.Accounts
{
    public class ChangeUserPasswordDTO
    {
        public Guid ApplicationUserId { get; set; }
        public string NewPassword { get; set; }
    }
}
