using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppModelLibrary.CustomExceptions
{
    public class NoObjectsAvailableException : Exception
    {
        string msg = string.Empty;
        public NoObjectsAvailableException(string message)
        {
            msg = message;
        }
        public override string Message => msg;
    }
}
