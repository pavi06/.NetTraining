using PizzaShopAPI.Models;

namespace PizzaShopAPI.Interface
{
    public interface ITokenService
    {
        public string GenerateToken(Customer customer);
    }
}
