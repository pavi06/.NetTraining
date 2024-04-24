using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppModelLibrary.CustomExceptions
{
    public class NullValueException : Exception
    {
        string msg = string.Empty;
        public NullValueException(string message)
        {
            msg = $"{message}";
        }
        public override string Message => msg;
    }
}
