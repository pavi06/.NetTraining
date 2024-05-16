using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class StockRepository : IRepository<int, Stock>
    {
        private readonly PizzaShopContext _context;
        public StockRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Stock> Add(Stock item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Stock> Delete(int pizzakey)
        {
            var stock = await Get(pizzakey);
            if (stock != null)
            {
                _context.Remove(stock);
                await _context.SaveChangesAsync();
                return stock;
            }
            throw new Exception("No such pizza available to get the stock!");
        }

        public async Task<Stock> Get(int pizzakey)
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(e => e.PizzaId == pizzakey);
            return stock;
        }

        public async Task<IEnumerable<Stock>> Get()
        {
            var stockList = await _context.Stock.ToListAsync();
            return stockList;

        }

        public async Task<Stock> Update(Stock item)
        {
            var stock = await Get(item.PizzaId);
            if (stock != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return stock;
            }
            throw new Exception("No such Pizza available to get the stock!");
        }
    }
}
