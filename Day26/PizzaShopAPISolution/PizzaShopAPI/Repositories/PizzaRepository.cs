using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaShopContext _context;
        public PizzaRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            if (_context.Pizza.Any(p => p.Name == item.Name && p.size == item.size 
            && p.Description == item.Description && p.IsAvailable == item.IsAvailable))
                return null;
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new Exception("No such pizza available!");
        }

        public async Task<Pizza> Get(int key)
        {
            var pizza = await _context.Pizza.FirstOrDefaultAsync(e => e.PizzaId == key);
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            var pizza = await _context.Pizza.ToListAsync();
            return pizza;

        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.PizzaId);
            if (pizza != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new Exception("No such Pizza available!");
        }
    }
}
