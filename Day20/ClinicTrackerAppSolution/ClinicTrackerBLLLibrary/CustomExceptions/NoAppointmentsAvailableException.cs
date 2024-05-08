using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLLibrary.CustomExceptions
{
    public class NoAppointmentsAvailableException : Exception
    {
        string msg = string.Empty;
        public NoAppointmentsAvailableException()
        {
            msg = "No appointments available!";
        }
        public override string Message => msg;
    }
}
