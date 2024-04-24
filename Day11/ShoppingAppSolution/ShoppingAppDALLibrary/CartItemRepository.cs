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
