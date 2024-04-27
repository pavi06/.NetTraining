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
        public async Task<int> AddCustomer(Customer customer)
        {
            var retrivedCustomer = await _customerRepository.Add(customer);
            if (retrivedCustomer != null)
            {
                Cart cart = new Cart(retrivedCustomer.Id,retrivedCustomer,new List<CartItem>(),0,0,0);
                _cartRepository.Add(cart);
                return retrivedCustomer.Id;
            }
            throw new ObjectAlreadyExistsException("Customer");
        }

        public async Task<Customer> DeleteCustomerById(int id)
        {
            var customer = _customerRepository.Delete(id).Result;
            if (customer != null)
            {
                return customer;
            }
            throw new ObjectNotAvailableException($"Customer with id - {id} not available!");
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            var customerList = _customerRepository.GetAll().Result;
            if (customerList!=null)
            {
                return customerList.ToList();
            }
            throw new NoObjectsAvailableException("No Customers Available!");
        }

        public async Task<List<int>> GetAllCustomerId()
        {
            List<int> customerIds = new List<int>();
            foreach (var customer in await GetAllCustomer())
            {
                customerIds.Add(customer.Id);
            }
            if(customerIds!=null)
            {
                return customerIds.ToList();
            }
            throw new NoObjectsAvailableException("No customers Available!");
        }

        public async Task<List<CartItem>> GetCartByCustomerId(int id)
        {
            var cartList = await _cartRepository.GetAll();
            return cartList.FirstOrDefault(c => c.CustomerId == id).CartItems;
            //throw new ObjectNotAvailableException($"Cart for the customer id - {id} is not available!");
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetByKey(id);
            if (customer != null)
            {
                return customer;
            }
            throw new ObjectNotAvailableException($"Customer with id - {id} not available!");
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var updatedCustomer = _customerRepository.Update(customer).Result;
            if (updatedCustomer != null)
            {
                return updatedCustomer;
            }
            throw new ObjectNotAvailableException($"Customer with id - {customer.Id} not available!");
        }

        public async Task<bool> UpdateCustomerAddressById(int id, string newAddress)
        {
            var customer = await GetCustomerById(id);
            customer.Address = newAddress;
            var updatedCustomer = UpdateCustomer(customer);
            if (updatedCustomer != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCustomerPhoneNumberById(int id, string newPhoneNumber)
        {
            var customer = await GetCustomerById(id);
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
