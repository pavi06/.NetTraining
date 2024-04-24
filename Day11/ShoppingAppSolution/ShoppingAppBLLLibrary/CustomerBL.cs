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
        public static int idCount = 0;

        public CustomerBL(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public int AddCustomer(Customer customer)
        {
            customer.Id = ++idCount;
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
