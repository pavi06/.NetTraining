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
    public class CartItemBL : ICartItemService
    {
        readonly IRepository<int, CartItem> _cartItemRepository;
        readonly IRepository<int, Cart> _cartRepository;
        CartBL cartBl;

        public CartItemBL(IRepository<int, CartItem> cartItemRepository, IRepository<int, Cart> cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            cartBl = new CartBL(_cartRepository);
        }

        public async Task<int> AddCartItem(CartItem cartItem)
        {

            var retrivedCart =_cartItemRepository.Add(cartItem).Result;
            if (retrivedCart != null)
            {
                Cart cart = await _cartRepository.GetByKey(cartItem.CartId);
                if (cart != null)
                {
                    if (cart.CartItems.Count() < 5)
                    {
                        cart.CartItems.Add(cartItem);
                        cart.TotalAmount = await cartBl.GetTotalAmountOfCartItems(cartItem.CartId);
                        cart.Discount = cartBl.GetDiscountPercent(cart.CartItems.Count(),cart.TotalAmount);
                        cart.DiscountAmount = cartBl.GetDiscountAmount(cartBl.GetCartItemsCount(cartItem.CartId).Result,cart.TotalAmount);
                        cart.ShippingCharges = cartBl.GetShippingCharges(cart.TotalAmount);
                    }                        
                    else
                        throw new CartLimitExceedsException();
                }
                var updatedCart = await _cartRepository.Update(cart);

                if (updatedCart == null && cart!=null)
                {
                    throw new ObjectNotAvailableException($"Cart with id - {cart.Id} not Available!");
                }
                return retrivedCart.Id;
            }
            throw new ObjectAlreadyExistsException("CartItem");
        }

        public async Task<CartItem> DeleteCartItem(int cartId)
        {
            var cartItem = await _cartItemRepository.Delete(cartId);
            if (cartItem != null)
            {
                Cart cart = new Cart();
                cart = await _cartRepository.GetByKey(cartItem.CartId);
                cart.CartItems.Remove(cartItem);
                cart.TotalAmount = await cartBl.GetTotalAmountOfCartItems(cartItem.CartId);
                cart.Discount = cartBl.GetDiscountPercent(cart.CartItems.Count(), cart.TotalAmount);
                cart.DiscountAmount = cartBl.GetDiscountAmount(cartBl.GetCartItemsCount(cartItem.CartId).Result, cart.TotalAmount);
                cart.ShippingCharges = cartBl.GetShippingCharges(cart.TotalAmount);
                var updatedCart = await _cartRepository.Update(cart);
                if (updatedCart == null)
                {
                    throw new ObjectNotAvailableException($"Cart with id - {cart.Id} not Available!");
                }
                return cartItem;
            }
            throw new ObjectNotAvailableException($"CartItem with id - {cartId} not Available!");
        }

        public async Task<CartItem> GetCartItemById(int cartId)
        {
            var retrivedCart = await _cartItemRepository.GetByKey(cartId);
            if (retrivedCart != null)
            {
                return retrivedCart;
            }
            throw new ObjectNotAvailableException($"CartItem with id - {cartId} not Available!");
        }

        public async Task<CartItem> UpdateCartItem(CartItem cartItem)
        {
            var updatedCartItem = await _cartItemRepository.Update(cartItem);
            if (updatedCartItem != null)
            {
                return updatedCartItem;
            }
            throw new ObjectNotAvailableException($"CartItem with id - {cartItem.Id} not available!");

        }
        public async Task<bool> UpdateCartIdById(int newCartId, int id)
        {
            var cartItem = await GetCartItemById(id);
            cartItem.CartId = newCartId;
            var updateProduct = UpdateCartItem(cartItem);
            if (updateProduct != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePriceExpiryDateById(int cartId, DateTime dateTime)
        {
            var cartItem = await GetCartItemById(cartId);
            cartItem.PriceExpiryDate = dateTime;
            var updateProduct = UpdateCartItem(cartItem);
            if (updateProduct != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateQuantityById(int cartId, int quantity)
        {
            var cartItem = await GetCartItemById(cartId);
            cartItem.Quantity = quantity;
            var updateProduct = await UpdateCartItem(cartItem);
            if (updateProduct != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateDiscountById(int id, double discount)
        {
            var cartItem = await GetCartItemById(id);
            cartItem.Discount = discount;
            var updateProduct = UpdateCartItem(cartItem);
            if (updateProduct != null)
            {
                return true;
            }
            return false;
        }
    }
}
