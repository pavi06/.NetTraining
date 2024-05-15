using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface IUserService
    {
        public Task<Customer> Login(UserLoginDTO loginDTO);
        public Task<Customer> Register(CustomerDTO customerDTO);
    }
}
