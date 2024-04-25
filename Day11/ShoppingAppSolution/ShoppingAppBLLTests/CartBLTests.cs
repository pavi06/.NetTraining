using ShoppingAppBLLLibrary;
using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary.CustomExceptions;
using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLTests
{
    public class CartBLTests
    {
        IRepository<int, Cart> cartRepository;
        ICartService cartService;

        [SetUp]
        public void Setup()
        {

            cartRepository = new CartRepository();
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem(0, 0, new Product(0, "Stick Pen Box", 240.0, "Stationary", 40), 2, 480,0, new DateTime(2024, 05, 12)));
            Cart cart = new Cart() { CustomerId = 0, Customer = new Customer(0, "Pavi", "78786756456", "no.3 nehru street, chennai"), CartItems = cartItems };
            cartRepository.Add(cart);
            cartService = new CartBL(cartRepository);
        }

        [Test]
        public void AddCartPassTest()
        {
            //Arrange
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem(0, 0, new Product(0, "Stick Pen Box", 240.0, "Stationary", 40), 2, 480,0, new DateTime(2024, 05, 12)));
            Cart cart = new Cart() { CustomerId = 0, Customer = new Customer(0, "Pavi", "78786756456", "no.3 nehru street, chennai"), CartItems = cartItems };
            //action
            var addedCart = cartService.AddCart(cart);
            //Assert
            Assert.IsNotNull(addedCart);
        }


        [Test]
        public void CartAlreadyExistsExceptionTest()
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem(0, 0, new Product(0, "Stick Pen Box", 240.0, "Stationary", 40), 2, 480,0, new DateTime(2024, 05, 12)));
            Cart cart = new Cart() { CustomerId = 0, Customer = new Customer(0, "Pavi", "78786756456", "no.3 nehru street, chennai"), CartItems = cartItems };
            //Action
            var exception = Assert.Throws<ObjectAlreadyExistsException>(() => cartService.AddCart(cart));
            //Assert
            Assert.AreEqual("Cart Already Exists!", exception.Message);
        }

        [Test]
        public void GetCartPassTest()
        {
            //action
            var cart = cartService.GetCartById(1);
            //Assert
            Assert.IsNotNull(cart);
        }

        [Test]
        public void CartNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => cartService.GetCartById(id));
            //Assert
            Assert.AreEqual($"Cart with id - {id} not Available!", exception.Message);
        }

        [Test]
        public void DeleteCartPassTest()
        {
            //action
            var cart = cartService.DeleteCartById(1);
            //Assert
            Assert.IsNotNull(cart);
        }

        [Test]
        public void DeleteCartNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => cartService.DeleteCartById(id));
            //Assert
            Assert.AreEqual($"Cart with id - {id} not Available!", exception.Message);
        }


        [Test]
        public void UpdateCartPassTest()
        {
            var cart = cartService.GetCartById(1);
            cart.Customer = new Customer();
            var updatedProduct = cartService.UpdateCart(cart);
            Assert.IsNotNull(updatedProduct);

        }
        [Test]
        public void UpdateCartItemExceptionTest()
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem(0, 0, new Product(0, "Stick Pen Box", 240.0, "Stationary", 40), 2, 480,0, new DateTime(2024, 05, 12)));
            Cart cart = new Cart() { Id = 1,CustomerId = 0, Customer = new Customer(0, "Pavi", "78786756456", "no.3 nehru street, chennai"), CartItems = cartItems };
            var exception = Assert.Throws<ObjectNotAvailableException>(() => cartService.UpdateCart(cart));
            //Assert
            Assert.AreEqual($"Cart with id - {cart.Id} not Available!", exception.Message);
        }

        
    }
}
