using ShoppingAppModelLibrary;
using ShoppingAppModelLibrary.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override Customer Add(Customer item)
        {
            if (items.Contains(item))
            {
                return null;
            }
            if(items.Count() > 0)
            {
                item.Id = items.Max(c => c.Id) + 1;
            }
            else
            {
                item.Id = 1;
            }
            return base.Add(item);
        }
        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override Customer GetByKey(int key)
        {
            Customer customer = items.FirstOrDefault(c => c.Id == key);
            return customer;
        }

        public override Customer Update(Customer item)
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
