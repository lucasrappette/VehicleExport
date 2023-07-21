using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExport.App.Exceptions
{
    public class RequeueLimitException : Exception
    {
        public RequeueLimitException(string message) : base(message)
        {
        }
    }
}
