using PizzaShopAPI.Models;

namespace PizzaShopAPI.Interface
{
    public interface IPizzaService
    {
        public Task<List<Pizza>> GetAllAvailablePizza();
    }
}
