using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary.CustomExceptions
{
    public class NoTransactionAvailableException : Exception
    {
        string msg = string.Empty;
        public NoTransactionAvailableException(string message)
        {
            msg = $"No transaction done yet {message}!";
        }
        public override string Message => msg;
    }
}
