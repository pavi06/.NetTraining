using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Add(CartItem item)
        {
            if (items.ToList().Exists(c => c.ProductId == item.ProductId && c.CartId == item.CartId && c.Product == item.Product && c.Quantity == item.Quantity && c.Price == item.Price && c.PriceExpiryDate == item.PriceExpiryDate))
            {
                return null;
            }
            item.Id = items.Max(c => c.Id) + 1;
            return base.Add(item);
        }
        public override CartItem Delete(int key)
        {
            CartItem cartItem = GetByKey(key);
            if (cartItem != null)
            {
                items.Remove(cartItem);
            }
            return cartItem;
        }

        public override CartItem GetByKey(int key)
        {

            CartItem cartItem = items.FirstOrDefault( i => i.CartId == key);
            return cartItem;
        }

        public override CartItem Update(CartItem item)
        {
            int index = items.IndexOf(item);
            if (index != -1)
            {
                items[index] = item;
                return item;
            }
            return null;
        }
    }
}
