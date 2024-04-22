using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary.CustomExceptions
{
    public class NoPassengersAvailableException : Exception
    {
        string msg = string.Empty;
        public NoPassengersAvailableException(string message)
        {
            msg = $"No Passengers available {message}!";
        }
        public override string Message => msg;
    }
}
