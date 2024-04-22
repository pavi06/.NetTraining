using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary.CustomExceptions
{
    public class NullValueException : Exception
    {
        string msg = string.Empty;
        public NullValueException(string message)
        {
            msg = $"The value is not assigned properly {message}!";
        }
        public override string Message => msg;
    }
}
