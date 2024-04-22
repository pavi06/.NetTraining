using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary.CustomExceptions
{
    public class ObjectNotAvailableException : Exception
    {
        string msg = "";
        public ObjectNotAvailableException(string newMsg)
        {
            msg = newMsg;
        }
        public override string Message => msg;
    }
}
