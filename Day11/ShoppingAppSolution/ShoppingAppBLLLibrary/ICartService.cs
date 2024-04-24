﻿using ShoppingAppModelLibrary;
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
        Customer GetCustomerByCartId(int cartId);
        int GetCustomerIdByCartId(int cartId);        
        List<CartItem> GetCartItemsByCartId(int cartId);
        public int GetCartItemsCount(int cartId);
        public double GetTotalAmountOfCartItems(int cartId);
        public double GetShippingCharges(double totalAmount);
        public double GetDiscountAmount(int cartItems, double price);
        
    }
}
