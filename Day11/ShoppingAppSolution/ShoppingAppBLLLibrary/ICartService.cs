using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLLibrary
{
    public interface ICartService
    {
        int AddCart(Cart cart);
        Cart GetCartById(int cartId);
        Cart DeleteCartById(int cartId);
        Cart UpdateCart(Cart cart);
        List<Cart> GetAllCarts();   
        Cart GetCartByCustomerId(int customerId);
        Customer GetCustomerByCartId(int cartId);
        int GetCustomerIdByCartId(int cartId);        
        List<CartItem> GetCartItemsByCartId(int cartId);
        List<CartItem> GetAllCartItemsWithDiscount(int cartId);
        public int GetCartItemsCount(int cartId);
        public double GetTotalAmountOfCartItems(int cartId);
        public double GetShippingCharges(double totalAmount);
        public double GetDiscountPercent(int cartItems, double price);
        public double GetDiscountAmount(int cartItems, double price);
        public Product DeleteCartItemByCutsomerIdAndProductId(int customerId,int productId);
        
    }
}
