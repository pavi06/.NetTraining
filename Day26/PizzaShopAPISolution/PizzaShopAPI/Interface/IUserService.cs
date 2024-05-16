using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<CustomerReturnDTO> Register(CustomerDTO customerDTO);
    }
}
