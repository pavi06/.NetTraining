using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppModelLibrary.CustomExceptions
{
    public class ObjectAlreadyExistsException : Exception
    {
        string msg = string.Empty;
        public ObjectAlreadyExistsException(string message) {
            msg = $"{message} Already Exists!";
        }
        public override string Message => msg;
    }
}
