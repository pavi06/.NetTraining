using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerBLLLibrary.Exceptions
{
    public class ObjectAlreadyExistsException : Exception
    {
        public string msg = "";
        public ObjectAlreadyExistsException(string message) { 
            msg= message;
        }
        public override string Message => msg;
    }
}
