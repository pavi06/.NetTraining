using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerBLLLibrary.CustomExceptions
{
    public class NoObjectsAvailableException : Exception
    {
        public string msg = "";
        public NoObjectsAvailableException(string message) {
            msg = message;
        }
        public override string Message => msg;
    }
}
