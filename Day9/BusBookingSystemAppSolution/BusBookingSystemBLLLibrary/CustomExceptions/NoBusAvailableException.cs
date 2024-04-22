using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary.CustomExceptions
{
    public class NoBusAvailableException : Exception
    {
        string msg = string.Empty;
        public NoBusAvailableException(string message)
        {
            msg = $"No bus available {message}!";
        }
        public override string Message => msg;
    }
}
