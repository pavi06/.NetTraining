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

        public CartBL(IRepository<int, Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public int AddCart(Cart cart)
        {
            
            var retrivedCart = _cartRepository.Add(cart);
            if (retrivedCart != null)
            {
                return retrivedCart.Id;
            }
            throw new ObjectAlreadyExistsException("Cart");
        }

        public Cart GetCartById(int cartId)
        {
            var retrivedCart = _cartRepository.GetByKey(cartId);
            if (retrivedCart != null)
            {
                return retrivedCart;
            }
            throw new ObjectNotAvailableException($"Cart with id - {cartId} not Available!");
        }

        public Cart DeleteCartById(int cartId)
        {
            var cart = _cartRepository.Delete(cartId);
            if (cart != null)
            {
                return cart;
            }
            throw new ObjectNotAvailableException($"Cart with id - {cartId} not Available!");
        }

        public Cart UpdateCart(Cart cart)
        {
            var updatedCart = _cartRepository.Update(cart);
            if (updatedCart != null)
            {
                return updatedCart;
            }
            throw new ObjectNotAvailableException($"Cart with id - {cart.Id} not Available!");
        }

        public List<CartItem> GetCartItemsByCartId(int cartId)
        {
            var cart = GetCartById(cartId);
            if (cart.CartItems.ToList().Count() > 0)
            {
                return cart.CartItems.ToList();
            }
            throw new NoObjectsAvailableException("No Items where added to the cart");
        }

        public List<CartItem> GetAllCartItemsWithDiscount(int cartId)
        {
            var cartItems = GetCartItemsByCartId(cartId);
            var itemsWithDiscount = from c in cartItems
                                    where c.Discount > 0
                                    select c;
            if (itemsWithDiscount.Count() > 0) { 
                return itemsWithDiscount.ToList();
            }
            throw new NoObjectsAvailableException("No Items with discount where added to the cart");
        }

        public int GetCartItemsCount(int cartId)
        {
            var count = GetCartItemsByCartId(cartId).Count();
            if (count > 0)
            {
                return count;
            }
            throw new NoObjectsAvailableException("No Items where added to the cart");
        }

        public Customer GetCustomerByCartId(int cartId)
        {
            var cart = GetCartById(cartId);
            if (cart.Customer != null)
            {
                return cart.Customer;
            }
            throw new NullValueException("Customer value is null. Customer is Not associated properly with the cart");
        }

        public int GetCustomerIdByCartId(int cartId)
        {
            var customer = GetCustomerByCartId(cartId);
            return customer.Id;

        }
        public double GetTotalAmountOfCartItems(int cartId)
        {
            var cartItems = GetCartItemsByCartId(cartId);
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

        public List<Cart> GetAllCarts()
        {
            var cartList = _cartRepository.GetAll();
            if(cartList != null)
            {
                return cartList.ToList();
            }
            throw new NoObjectsAvailableException("No carts Available!");
        }

        public Cart GetCartByCustomerId(int customerId)
        {
            var carts = GetAllCarts();
            var customerCart = carts.FirstOrDefault(c => c.CustomerId == customerId);
            return customerCart;
            
        }
    }
}
