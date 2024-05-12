using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerBLLLibrary.CustomExceptions
{
    public class ObjectNotAvailableException : Exception
    {
        public string msg = "";
        public ObjectNotAvailableException(string msg1) { 
            msg = msg1;
        }

        public override string Message => msg;
    }
}
