using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppModelLibrary.CustomExceptions
{
    public class CartLimitExceedsException : Exception
    {
        string msg = string.Empty;
        public CartLimitExceedsException()
        {
            msg = "OOps!! Your cart Exceeds the Limit!! Can have only 5 Products.\nNo more products can be added!";
        }
        public override string Message => msg;
    }
}
