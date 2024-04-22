using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary.CustomExceptions
{
    public class NoBusRoutesAvailableException : Exception
    {
        string msg = string.Empty;
        public NoBusRoutesAvailableException(string message)
        {
            msg = $"No BusRoutes available {message}!";
        }
        public override string Message => msg;
    }
}
