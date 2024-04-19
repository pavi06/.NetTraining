using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLLibrary.CustomExceptions
{
    public class DepartmentNotFoundException : Exception
    {
        string msg;
        public DepartmentNotFoundException()
        {
            msg = "Department is not available";
        }
        public override string Message => msg;
    }
}
