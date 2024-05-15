using PizzaShopAPI.Interface;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Repositories;

namespace PizzaShopAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _pizzaRepo;
        private readonly IRepository<int, Ingredient> _ingrRepo;


        public PizzaService(IRepository<int, Pizza> pizzaRepository, IRepository<int, Ingredient> ingrRepository) { 
            _pizzaRepo = pizzaRepository;
            _ingrRepo = ingrRepository;
        }
        public async Task<List<Pizza>> GetAllAvailablePizza()
        {
            var pizzaList = await _pizzaRepo.Get();
            if (pizzaList == null)
                throw new Exception("No pizza available!");
            List<Pizza> availablePizza = new List<Pizza>();
            foreach(var pizza in pizzaList)
            {
                var ingredients = pizza.Ingredients;
                bool flag = false;
                foreach(var ingredient in ingredients)
                {
                    var ingredientStock = await _ingrRepo.Get(ingredient.IngrId);
                    if (ingredient.QuantityNeeded > ingredientStock.QuantityInStock)
                    {
                        flag = true; 
                        break;
                    }                     

                }
                if (!flag)
                {
                    availablePizza.Add(pizza);
                }
            }
            return availablePizza;
        }
    }
}
