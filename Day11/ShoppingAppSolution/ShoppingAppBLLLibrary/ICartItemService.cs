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
        Task<int> AddCartItem(CartItem cartItem);
        Task<CartItem> GetCartItemById(int cartId);
        Task<CartItem> DeleteCartItem(int cartId);
        Task<CartItem> UpdateCartItem(CartItem cartItem);
        Task<bool> UpdateQuantityById(int cartId, int quantity);
        Task<bool> UpdatePriceExpiryDateById(int cartId, DateTime dateTime);
        Task<bool> UpdateDiscountById(int id, double discount);
        Task<bool> UpdateCartIdById(int newCartId, int id);

    }
}
