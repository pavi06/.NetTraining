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

        public CartItemBL(IRepository<int, CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public int AddCartItem(CartItem cartItem)
        {
          
            var retrivedCart = _cartItemRepository.Add(cartItem);
            if (retrivedCart != null)
            {
                return retrivedCart.Id;
            }
            throw new ObjectAlreadyExistsException("CartItem");
        }

        public CartItem DeleteCartItem(int cartId)
        {
            var cart = _cartItemRepository.Delete(cartId);
            if (cart != null)
            {
                return cart;
            }
            throw new ObjectNotAvailableException($"CartItem with id - {cartId} not Available!");
        }

        public CartItem GetCartItemById(int cartId)
        {
            var retrivedCart = _cartItemRepository.GetByKey(cartId);
            if (retrivedCart != null)
            {
                return retrivedCart;
            }
            throw new ObjectNotAvailableException($"CartItem with id - {cartId} not Available!");
        }

        public CartItem UpdateCartItem(CartItem cartItem)
        {
            var updatedCartItem = _cartItemRepository.Update(cartItem);
            if (updatedCartItem != null)
            {
                return updatedCartItem;
            }
            throw new ObjectNotAvailableException($"CartItem with id - {cartItem.Id} not available!");

        }
        public bool UpdateCartIdById(int newCartId, int id)
        {
            var cartItem = GetCartItemById(id);
            cartItem.CartId = newCartId;
            var updateProduct = UpdateCartItem(cartItem);
            if (updateProduct != null)
            {
                return true;
            }
            return false;
        }

        public bool UpdatePriceExpiryDateById(int cartId, DateTime dateTime)
        {
            var cartItem = GetCartItemById(cartId);
            cartItem.PriceExpiryDate = dateTime;
            var updateProduct = UpdateCartItem(cartItem);
            if (updateProduct != null)
            {
                return true;
            }
            return false;
        }

        public bool UpdateQuantityById(int cartId, int quantity)
        {
            var cartItem = GetCartItemById(cartId);
            cartItem.Quantity = quantity;
            var updateProduct = UpdateCartItem(cartItem);
            if (updateProduct != null)
            {
                return true;
            }
            return false;
        }
    }
}
