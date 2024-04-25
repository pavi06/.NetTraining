using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLLibrary
{
    public interface ICartItemService
    {
        int AddCartItem(CartItem cartItem);
        CartItem GetCartItemById(int cartId);
        CartItem DeleteCartItem(int cartId);
        CartItem UpdateCartItem(CartItem cartItem);
        bool UpdateQuantityById(int cartId, int quantity);
        bool UpdatePriceExpiryDateById(int cartId, DateTime dateTime);
        bool UpdateDiscountById(int id, double discount);
        bool UpdateCartIdById(int newCartId, int id);

    }
}
