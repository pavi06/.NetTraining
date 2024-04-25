using ShoppingAppModelLibrary;
using ShoppingAppModelLibrary.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Add(Product item)
        {
            if (items.Contains(item))
                return null;
            if (items.Count() > 0)
            {
                item.Id = items.Max(p => p.Id) + 1;
            }
            else { 
                item.Id = 1;
            }
            return base.Add(item);
        }
        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override Product GetByKey(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            return product;
        }

        public override Product Update(Product item)
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
