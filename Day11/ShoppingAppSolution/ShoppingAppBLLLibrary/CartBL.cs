using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary;
using ShoppingAppModelLibrary.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLLibrary
{
    public class CartBL : ICartService
    {
        readonly IRepository<int, Cart> _cartRepository;
        readonly IRepository<int, CartItem> _cartItemRepository;

        public CartBL(IRepository<int, Cart> cartRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = new CartItemRepository();
        }
        public async Task<int> AddCart(Cart cart)
        {
            
            var retrivedCart = await _cartRepository.Add(cart);
            if (retrivedCart != null)
            {
                return retrivedCart.Id;
            }
            throw new ObjectAlreadyExistsException("Cart");
        }

        public async Task<Cart> GetCartById(int cartId)
        {
            var retrivedCart = await _cartRepository.GetByKey(cartId);
            if (retrivedCart != null)
            {
                return retrivedCart;
            }
            throw new ObjectNotAvailableException($"Cart with id - {cartId} not Available!");
        }

        public async Task<Cart> DeleteCartById(int cartId)
        {
            var cart = await _cartRepository.Delete(cartId);
            if (cart != null)
            {
                return cart;
            }
            throw new ObjectNotAvailableException($"Cart with id - {cartId} not Available!");
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var updatedCart = await _cartRepository.Update(cart);
            if (updatedCart != null)
            {
                return updatedCart;
            }
            throw new ObjectNotAvailableException($"Cart with id - {cart.Id} not Available!");
        }

        public async Task<List<CartItem>> GetCartItemsByCartId(int cartId)
        {
            var cart = await GetCartById(cartId);
            if (cart.CartItems.ToList().Count() > 0)
            {
                return cart.CartItems.ToList();
            }
            throw new NoObjectsAvailableException("No Items where added to the cart");
        }

        public async Task<List<CartItem>> GetAllCartItemsWithDiscount(int cartId)
        {
            var cartItems = await GetCartItemsByCartId(cartId);
            var itemsWithDiscount = from c in cartItems
                                    where c.Discount > 0
                                    select c;
            if (itemsWithDiscount!= null) { 
                return itemsWithDiscount.ToList();
            }
            throw new NoObjectsAvailableException("No Items with discount where added to the cart");
        }

        public async Task<int> GetCartItemsCount(int cartId)
        {
            var items = await GetCartItemsByCartId(cartId);
            if (items.Count() > 0)
            {
                return items.Count();
            }
            throw new NoObjectsAvailableException("No Items where added to the cart");
        }

        public async Task<Customer> GetCustomerByCartId(int cartId)
        {
            var cart = await GetCartById(cartId);
            if (cart.Customer != null)
            {
                return cart.Customer;
            }
            throw new NullValueException("Customer value is null. Customer is Not associated properly with the cart");
        }

        public async Task<int> GetCustomerIdByCartId(int cartId)
        {
            var customer = await GetCustomerByCartId(cartId);
            return customer.Id;

        }
        public async Task<double> GetTotalAmountOfCartItems(int cartId)
        {
            var cartItems = await GetCartItemsByCartId(cartId);
            double totalAmount = 0.0;
            foreach (var item in cartItems)
            {
                double price = item.Price - (item.Discount / 100) * item.Price;
                if (item.PriceExpiryDate > DateTime.Now)
                {                    
                    totalAmount += price * item.Quantity;
                }
                else
                {
                    totalAmount += item.Product.Price * item.Quantity;
                }
            }
            return totalAmount;
        }
        public double GetDiscountPercent(int cartItems, double price)
        {
            if (cartItems == 3 && price == 1500)
            {
                return 5;
            }
            return 0.0;
        }

        public double GetDiscountAmount(int cartItems, double price)
        {
            double discountAmount = price;
            if (cartItems == 3 && price == 1500)
            {
                discountAmount = price - (0.05 * price);
            }
            return discountAmount;
        }

        public double GetShippingCharges(double totalAmount)
        {
            if (totalAmount < 100)
            {
                return 100;
            }
            return 0;
        }

        public async Task<List<Cart>> GetAllCarts()
        {
            var cartList = await _cartRepository.GetAll();
            if(cartList != null)
            {
                return cartList.ToList();
            }
            throw new NoObjectsAvailableException("No carts Available!");
        }

        public async Task<Cart> GetCartByCustomerId(int customerId)
        {
            var carts = await GetAllCarts();
            var customerCart = carts.FirstOrDefault(c => c.CustomerId == customerId);
            return customerCart;
            
        }

        public async Task<Product> DeleteCartItemByCutsomerIdAndProductId(int customerId, int productId)
        {
            var cart = await GetCartByCustomerId(customerId);
            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(c => c.ProductId == productId);
                if(cartItem != null)
                {
                    var product = cartItem.Product;
                    cart.CartItems.Remove(cartItem);
                    _cartItemRepository.Delete(cartItem.Id);
                    _cartRepository.Update(cart);
                    return product;
                }
                throw new ObjectNotAvailableException("Product is not available in your cart!");
            }
            throw new NullValueException("Your Cart is Empty!");
            
        }
    }
}
