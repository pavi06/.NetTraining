using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLLibrary.CustomExceptions
{
    public class NoEmployeesAvailableException : Exception
    {
        string msg;
        public NoEmployeesAvailableException()
        {
            msg = "No Employee exists!";
        }
        public override string Message => msg;
    }
}
