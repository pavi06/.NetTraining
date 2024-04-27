using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLLibrary
{
    public interface ICustomerService
    {
        Task<int> AddCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<List<CartItem>> GetCartByCustomerId(int id);
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> DeleteCustomerById(int id);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<bool> UpdateCustomerPhoneNumberById(int id, string newPhoneNumber);
        Task<bool> UpdateCustomerAddressById(int id, string newAddress);
        Task<List<int>> GetAllCustomerId();
    }
}
