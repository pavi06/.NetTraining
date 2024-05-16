using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using System.Runtime.Serialization;

namespace PizzaShopAPI.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly PizzaShopContext _context;
        public CustomerRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer item)
        {
            if (_context.Customers.Any(c => c.CustName == item.CustName && c.CustPhone == item.CustPhone
            && c.Address == item.Address && c.City == item.City))
                return null;
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Customer> Delete(int key)
        {
            var customer = await Get(key);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            throw new Exception("No such customer available!");
        }

        public Task<Customer> Get(int key)
        {
            var customer = _context.Customers.FirstOrDefaultAsync(e => e.CustId == key);
            return customer;
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;

        }

        public async Task<Customer> Update(Customer item)
        {
            var customer = await Get(item.CustId);
            if (customer != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return customer;
            }
            throw new Exception("No such customer exists!");
        }
    }
}
