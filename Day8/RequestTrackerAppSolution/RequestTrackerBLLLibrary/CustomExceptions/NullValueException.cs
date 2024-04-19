using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLLibrary.CustomExceptions
{
    internal class NullValueException : Exception
    {
        string msg;
        public NullValueException()
        {
            msg = "Value is not assigned. It's a null value!!";
        }
        public override string Message => msg;
    }
}
