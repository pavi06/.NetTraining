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
        Task<int> AddCart(Cart cart);
        Task<Cart> GetCartById(int cartId);
        Task<Cart> DeleteCartById(int cartId);
        Task<Cart> UpdateCart(Cart cart);
        Task<List<Cart>> GetAllCarts();   
        Task<Cart> GetCartByCustomerId(int customerId);
        Task<Customer> GetCustomerByCartId(int cartId);
        Task<int> GetCustomerIdByCartId(int cartId);        
        Task<List<CartItem>> GetCartItemsByCartId(int cartId);
        Task<List<CartItem>> GetAllCartItemsWithDiscount(int cartId);
        public Task<int> GetCartItemsCount(int cartId);
        public Task<double> GetTotalAmountOfCartItems(int cartId);
        public double GetShippingCharges(double totalAmount);
        public double GetDiscountPercent(int cartItems, double price);
        public double GetDiscountAmount(int cartItems, double price);
        public Task<Product> DeleteCartItemByCutsomerIdAndProductId(int customerId,int productId);
        
    }
}
