using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDALTests
{
    public class CustomerRepositoryTests
    {
        IRepository<int, Customer> customerRepository;
        [SetUp]
        public void Setup()
        {
            customerRepository = new CustomerRepository();
            Customer customer = new Customer() { Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai"};
            customerRepository.Add(customer);
        }

        [Test]
        public void AddCustomerSuccessTest()
        {
            //Arrange 
            Customer customer = new Customer() { Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            //Action
            var result = customerRepository.Add(customer);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddCustomerFailTest()
        {
            //Arrange 
            Customer customer = new Customer() { Id = 1, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            //Action
            var result = customerRepository.Add(customer);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetCustomerByIdPassTest()
        {
            Customer customer = customerRepository.GetByKey(0);
            Assert.IsNotNull(customer);
        }

        [Test]
        public void GetCustomerByIdFailTest()
        {
            Customer customer = customerRepository.GetByKey(3);
            Assert.IsNull(customer);
        }

        [Test]
        public void DeleteCustomerByIdPassTest()
        {
            Customer customer = customerRepository.Delete(0);
            Assert.IsNotNull(customer);
        }

        [Test]
        public void DeleteCustomerByIdFailTest()
        {
            Customer customer = customerRepository.Delete(3);
            Assert.IsNull(customer);
        }

        [Test]
        public void UpdateCustomerByIdPassTest()
        {
            var customer = customerRepository.GetByKey(0);
            customer.Id = 1;
            Customer updatedCustomer = customerRepository.Update(customer);
            Assert.IsNotNull(updatedCustomer);
        }

        [Test]
        public void UpdateCustomerByIdFailTest()
        {
            Customer customer = new Customer() { Id = 1, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            Customer updatedCustomer = customerRepository.Update(customer);
            Assert.IsNull(updatedCustomer);
        }

        [Test]
        public void GetAllCustomersPassTest()
        {
            List<Customer> customers = (List<Customer>)customerRepository.GetAll();
            Assert.IsNotEmpty(customers);
        }

        [Test]
        public void GetAllCustomersFailTest()
        {
            List<Customer> customers = (List<Customer>)customerRepository.GetAll();
            Assert.IsEmpty(customers);
        }
    }
}
