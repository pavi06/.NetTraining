using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLLibrary.CustomExceptions
{
    public class ObjectAlreadyExistsException : Exception
    {
        string msg = "";
        public ObjectAlreadyExistsException(string newMsg)
        {
            msg = newMsg;
        }
        public override string Message => msg;
    }
}
