using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLLibrary.CustomExceptions
{
    public class EmployeeNotFoundException : Exception
    {
        string msg;
        public EmployeeNotFoundException()
        {
            msg = "No such employee Exists!";
        }
        public override string Message => msg;
    }
}
