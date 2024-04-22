using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary.CustomExceptions
{
    public class NoBookingsAvailableException : Exception
    {
        string msg = string.Empty;
        public NoBookingsAvailableException(string message)
        {
            msg = $"No bookings done yet {message}!";
        }
        public override string Message => msg;
    }
}
