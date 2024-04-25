using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary;
using ShoppingAppModelLibrary.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLLibrary
{
    public class CustomerBL : ICustomerService
    {
        readonly IRepository<int, Customer> _customerRepository;
        readonly IRepository<int, Cart> _cartRepository;

        public CustomerBL(IRepository<int, Customer> customerRepository, IRepository<int, Cart> cartRepository)
        {
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
        }
        public int AddCustomer(Customer customer)
        {
            var retrivedCustomer = _customerRepository.Add(customer);
            if (retrivedCustomer != null)
            {
                return retrivedCustomer.Id;
            }
            throw new ObjectAlreadyExistsException("Customer");
        }

        public Customer DeleteCustomerById(int id)
        {
            var customer = _customerRepository.Delete(id);
            if (customer != null)
            {
                return customer;
            }
            throw new ObjectNotAvailableException($"Customer with id - {id} not available!");
        }

        public List<Customer> GetAllCustomer()
        {
            var customerList = _customerRepository.GetAll();
            if (customerList.Count > 0)
            {
                return customerList.ToList();
            }
            throw new NoObjectsAvailableException("No Customers Available!");
        }

        public List<CartItem> GetCartByCustomerId(int id)
        {
            var cartList = _cartRepository.GetAll();
            //if (cartList.Any(c => c.CustomerId == id)) { 
            //    return cartList.First(c => c.CustomerId == id).CartItems;
            //}
            return cartList.FirstOrDefault(c => c.CustomerId == id).CartItems;
            //throw new ObjectNotAvailableException($"Cart for the customer id - {id} is not available!");
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _customerRepository.GetByKey(id);
            if (customer != null)
            {
                return customer;
            }
            throw new ObjectNotAvailableException($"Customer with id - {id} not available!");
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var updatedCustomer = _customerRepository.Update(customer);
            if (updatedCustomer != null)
            {
                return updatedCustomer;
            }
            throw new ObjectNotAvailableException($"Customer with id - {customer.Id} not available!");
        }

        public bool UpdateCustomerAddressById(int id, string newAddress)
        {
            var customer = GetCustomerById(id);
            customer.Address = newAddress;
            var updatedCustomer = UpdateCustomer(customer);
            if (updatedCustomer != null)
            {
                return true;
            }
            return false;
        }

        public bool UpdateCustomerPhoneNumberById(int id, string newPhoneNumber)
        {
            var customer = GetCustomerById(id);
            customer.PhoneNumber = newPhoneNumber;
            var updateCustomer = UpdateCustomer(customer);
            if (updateCustomer != null)
            {
                return true;
            }
            return false;
        }
    }
}
