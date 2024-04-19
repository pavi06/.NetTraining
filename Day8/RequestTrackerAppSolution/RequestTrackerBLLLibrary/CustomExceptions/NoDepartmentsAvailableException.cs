using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLLibrary.CustomExceptions
{
    public class NoDepartmentsAvailableException : Exception
    {
        string msg;
        public NoDepartmentsAvailableException()
        {
            msg = "No department is available till now";
        }
        public override string Message => msg;
    }
}
