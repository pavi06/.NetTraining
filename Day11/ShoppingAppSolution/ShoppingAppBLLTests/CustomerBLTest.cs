using ShoppingAppBLLLibrary;
using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary;
using ShoppingAppModelLibrary.CustomExceptions;
using System.Numerics;

namespace ShoppingAppBLLTests
{
    public class CustomerBLTest
    {

        IRepository<int, Customer> customerRepository;
        ICustomerService customerService;

        [SetUp]
        public void Setup()
        {

            customerRepository = new CustomerRepository();
            Customer customer = new Customer() { Id = 1, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            customerRepository.Add(customer);
            customer = new Customer() { Id = 2, Name = "Viji", PhoneNumber = "97677646", Address = "no.5 chennai" };
            customerRepository.Add(customer);
            customerService = new CustomerBL(customerRepository);
        }

        [Test]
        public void AddCustomerPassTest()
        {
            //Arrange
            Customer customer = new Customer() { Id = 1, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            //action
            var addedCustomer = customerService.AddCustomer(customer);
            //Assert
            Assert.IsNotNull(addedCustomer);
        }


        [Test]
        public void CustomerAlreadyExistsExceptionTest()
        {
            Customer customer = new Customer() { Id = 1, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            //Action
            var exception = Assert.Throws<ObjectAlreadyExistsException>(() => customerService.AddCustomer(customer));
            //Assert
            Assert.AreEqual("Customer Already Exists!", exception.Message);
        }

        [Test]
        public void GetCustomerPassTest()
        {
            //action
            var customer = customerService.GetCustomerById(1);
            //Assert
            Assert.IsNotNull(customer);
        }

        [Test]
        public void CustomerNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.GetCustomerById(id));
            //Assert
            Assert.AreEqual($"Customer with id - {id} not available!", exception.Message);
        }

        [Test]
        public void DeleteCustomerPassTest()
        {
            //action
            var customer = customerService.DeleteCustomerById(1);
            //Assert
            Assert.IsNotNull(customer);
        }

        [Test]
        public void DeleteCustomerNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.DeleteCustomerById(id));
            //Assert
            Assert.AreEqual($"Customer with id - {id} not available!", exception.Message);
        }


        [Test]
        public void UpdateCustomerPassTest()
        {
            Customer customer = new Customer() { Id = 1, Name = "Pavithra Pazhanivel", PhoneNumber = "97677646", Address = "no.3 chennai" };
            var updatedCustomer = customerService.UpdateCustomer(customer);
            Assert.IsNotNull(updatedCustomer);

        }
        [Test]
        public void UpdateCustomerExceptionTest()
        {
            Customer customer = new Customer() { Id = 1, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.UpdateCustomer(customer));
            //Assert
            Assert.AreEqual($"Customer with id - {customer.Id} not available!", exception.Message);
        }

        [Test]
        public void UpdateCustomerAddressPassTest()
        {
            Customer customer = new Customer() { Id = 1, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai, tamilNadu" };
            var updatedCustomer = customerService.UpdateCustomer(customer);
            Assert.IsNotNull(updatedCustomer);

        }
        [Test]
        public void UpdateCustomerAddressExceptionTest()
        {
            Customer customer = new Customer() { Id = 3, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.UpdateCustomer(customer));
            //Assert
            Assert.AreEqual($"Customer with id - {customer.Id} not available!", exception.Message);
        }

        [Test]
        public void UpdateCustomerPhoneNumberPassTest()
        {
            Customer customer = new Customer() { Id = 1, Name = "Pavi", PhoneNumber = "08765555555646", Address = "no.3 chennai" };
            var updatedCustomer = customerService.UpdateCustomer(customer);
            Assert.IsNotNull(updatedCustomer);

        }
        [Test]
        public void UpdateCustomerPhoneNumberExceptionTest()
        {
            Customer customer = new Customer() { Id = 3, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.UpdateCustomer(customer));
            //Assert
            Assert.AreEqual($"Customer with id - {customer.Id} not available!", exception.Message);
        }


    }
}