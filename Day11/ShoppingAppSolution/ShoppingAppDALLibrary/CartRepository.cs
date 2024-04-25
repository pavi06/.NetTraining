using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Add(Cart item)
        {
            if (items.Contains(item))
            {
                return null;
            }
            if (items.Count() > 0)
            {
                item.Id = items.Max(c => c.Id) + 1;
            }
            else { 
                item.Id = 1;
            }
            return base.Add(item);
        }
        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override Cart GetByKey(int key)
        {
            Cart cart = items.FirstOrDefault(c => c.Id  == key);
            return cart;
        }

        public override Cart Update(Cart item)
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
