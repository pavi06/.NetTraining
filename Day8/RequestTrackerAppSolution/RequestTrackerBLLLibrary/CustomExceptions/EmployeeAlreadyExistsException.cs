using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLLibrary.CustomExceptions
{
    public class EmployeeAlreadyExistsException : Exception
    {
        string msg;
        public EmployeeAlreadyExistsException()
        {
            msg = "Employee already Exists! You cannot add the employee again!";
        }
        public override string Message => msg;
    }
}
