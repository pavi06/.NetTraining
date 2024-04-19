using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLLibrary.CustomExceptions
{
    public class InvalidAttributeException : Exception
    {
        string msg;
        public InvalidAttributeException()
        {
            msg = "Attribute does not exists for this object. Provide valid attribute";
        }
        public override string Message => msg;
    }
}
