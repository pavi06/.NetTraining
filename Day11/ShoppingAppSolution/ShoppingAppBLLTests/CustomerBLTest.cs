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
        IRepository<int, Cart> cartRepository;
        ICustomerService customerService;

        [SetUp]
        public void Setup()
        {

            customerRepository = new CustomerRepository();
            Customer customer = new Customer() { Id = 1, Name = "Pavi", PhoneNumber = "97677646", Address = "no.3 chennai" };
            customerRepository.Add(customer);
            customer = new Customer() { Id = 2, Name = "Viji", PhoneNumber = "97677646", Address = "no.5 chennai" };
            customerRepository.Add(customer);
            Cart cart = new Cart() { CustomerId = 1, Customer = new Customer(1, "Pavi", "78786756456", "no.3 nehru street, chennai"), CartItems = new List<CartItem>() };
            cartRepository.Add(cart);
            customerService = new CustomerBL(customerRepository, cartRepository);
        }

        [Test]
        public void AddCustomerPassTest()
        {
            //Arrange`
            Customer customer = new Customer(4, "Pavithra Pazhanivel", "9769878646",  "no.3 chennai" );
            //action
            int addedCustomer = 0;
            addedCustomer = customerService.AddCustomer(customer);
            //Assert
            Assert.AreEqual(4,addedCustomer);
        }


        [Test]
        public void AddCustomerExceptionTest()
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
        public void GetCustomerExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.GetCustomerById(id));
            //Assert
            Assert.AreEqual($"Customer with id - {id} not available!", exception.Message);
        }

        [Test]
        public void GetAllCustomerPassTest()
        {
            //action
            var customer = customerService.GetAllCustomer();
            //Assert
            Assert.IsNotNull(customer);
        }

        [Test]
        public void GetAllCustomerExceptionTest()
        {
            //Action
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.GetAllCustomer());
            //Assert
            Assert.AreEqual("No Customers Available!", exception.Message);
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
            var customer = customerService.GetCustomerById(1);
            customer.PhoneNumber = "98966746465";
            var updatedCustomer = customerService.UpdateCustomer(customer);
            Assert.IsNotNull(updatedCustomer);

        }
        [Test]
        public void UpdateCustomerExceptionTest()
        {
            var customer = customerService.GetCustomerById(3);
            customer.PhoneNumber = "98966746465";
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.UpdateCustomer(customer));
            //Assert
            Assert.AreEqual($"Customer with id - {customer.Id} not Available!", exception.Message);
        }

        [Test]
        public void UpdateCustomerAddressPassTest()
        {
            var result = customerService.UpdateCustomerAddressById(1, "786456545646");
            Assert.IsTrue(result);

        }
        [Test]
        public void UpdateCustomerAddressExceptionTest()
        {
            var customer = customerService.GetCustomerById(3);
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.UpdateCustomerAddressById(customer.Id, "no.3 chennai, tamilNadu"));
            //Assert
            Assert.AreEqual($"Customer with id - {customer.Id} not Available!", exception.Message);
        }

        [Test]
        public void UpdateCustomerPhoneNumberPassTest()
        {
            var result = customerService.UpdateCustomerPhoneNumberById(1,"786456545646");
            Assert.IsTrue(result);

        }
        [Test]
        public void UpdateCustomerPhoneNumberExceptionTest()
        {
          
            var exception = Assert.Throws<ObjectNotAvailableException>(() => customerService.UpdateCustomerPhoneNumberById(5, "786456545646"));
            //Assert
            Assert.AreEqual($"Customer with id - 5 not Available!", exception.Message);
        }

        [Test]
        public void GetCartByCustomerIdPassTest() {
            var cart = customerService.GetCartByCustomerId(1);
            Assert.IsNotNull(cart);
        }

        [Test]
        public void GetCartByCustomerIdFailTest()
        {
            var cart = customerService.GetCartByCustomerId(5);
            Assert.IsNull(cart);
        }

    }
}