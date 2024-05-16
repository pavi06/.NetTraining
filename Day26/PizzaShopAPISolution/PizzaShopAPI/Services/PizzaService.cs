using PizzaShopAPI.Interface;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Repositories;

namespace PizzaShopAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _pizzaRepo;


        public PizzaService(IRepository<int, Pizza> pizzaRepository) { 
            _pizzaRepo = pizzaRepository;
        }

        public async Task<List<Pizza>> GetAllPizza()
        {
            var pizzaList = await _pizzaRepo.Get();
            if (pizzaList == null)
                throw new Exception("No pizza available!");
            return pizzaList.ToList();
        }

        public async Task<List<Pizza>> GetAllAvailablePizza()
        {
            var pizzaList = _pizzaRepo.Get().Result.Where(p=>p.IsAvailable == true);
            if (pizzaList == null)
                throw new Exception("No pizza available!");
            return pizzaList.ToList();
        }
    }
}
