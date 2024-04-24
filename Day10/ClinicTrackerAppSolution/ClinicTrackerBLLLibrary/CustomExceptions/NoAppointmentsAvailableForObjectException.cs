using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLLibrary.CustomExceptions
{
    public class NoAppointmentsAvailableForObjectException : Exception
    {
        string msg = string.Empty;
        public NoAppointmentsAvailableForObjectException(string message)
        {
            msg = $"No appointments available for {message}!";
        }
        public override string Message => msg;
    }
}
