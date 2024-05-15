using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class IngredientRepository : IRepository<int, Ingredient>
    {
        private readonly PizzaShopContext _context;
        public IngredientRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Ingredient> Add(Ingredient item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Ingredient> Delete(int key)
        {
            var ingredient = await Get(key);
            if (ingredient != null)
            {
                _context.Remove(ingredient);
                await _context.SaveChangesAsync();
                return ingredient;
            }
            throw new Exception("No such ingredient available!");
        }

        public Task<Ingredient> Get(int key)
        {
            var ingredient = _context.Ingredients.FirstOrDefaultAsync(e => e.IngrId == key);
            return ingredient;
        }

        public async Task<IEnumerable<Ingredient>> Get()
        {
            var ingredients = await _context.Ingredients.ToListAsync();
            return ingredients;

        }

        public async Task<Ingredient> Update(Ingredient item)
        {
            var ingredient = await Get(item.IngrId);
            if (ingredient != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return ingredient;
            }
            throw new Exception("No such Ingredient available!");
        }
    }
}
