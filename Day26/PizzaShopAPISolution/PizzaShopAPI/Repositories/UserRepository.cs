using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private PizzaShopContext _context;

        public UserRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }

        public async Task<User> Get(int key)
        {
            return (await _context.Users.SingleOrDefaultAsync(u => u.CustId == key)) ?? throw new Exception("No user with the given ID");
        }

        public async Task<IEnumerable<User>> Get()
        {
            return (await _context.Users.ToListAsync());
        }

        public async Task<User> Update(User item)
        {
            var user = await Get(item.CustId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }
    }
}
