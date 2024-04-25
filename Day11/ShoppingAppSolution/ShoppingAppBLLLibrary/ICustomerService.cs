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
        int AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        List<CartItem> GetCartByCustomerId(int id);
        List<Customer> GetAllCustomer();
        Customer DeleteCustomerById(int id);
        Customer UpdateCustomer(Customer customer);
        bool UpdateCustomerPhoneNumberById(int id, string newPhoneNumber);
        bool UpdateCustomerAddressById(int id, string newAddress);
    }
}
