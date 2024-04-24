using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace ShoppingAppDALTests
{
    public class CartRepositoryTests
    {
        IRepository<int, Cart> cartRepository;

        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem(0,0,new Product(0,"Stick Pen Box", 240.0, "Stationary",40),2,480,new DateTime(2024,05,12)));
            Cart cart = new Cart() { CustomerId = 0, Customer = new Customer(0,"Pavi","78786756456", "no.3 nehru street, chennai"), CartItems = cartItems };
            cartRepository.Add(cart);
        }

        [Test]
        public void AddCartSuccessTest()
        {
            //Arrange 
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem(1, 0, new Product(1, "Sketch Pen", 150.0, "Stationary", 40), 2, 300, new DateTime(2024, 05, 12)));
            Cart cart = new Cart() { CustomerId = 1, Customer = new Customer(0,"Pavi", "97866464" , "no.5 guru nagar, chennai"), CartItems = cartItems };
            //Action
            var result = cartRepository.Add(cart);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddCartFailTest()
        {
            //Arrange 
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem(1, 0, new Product(1, "Sketch Pen", 150.0, "Stationary", 40), 2, 300, new DateTime(2024, 05, 12)));
            Cart cart = new Cart() { Id=0, CustomerId = 1, Customer = new Customer(0, "Pavi","97866464", "no.5 guru nagar, chennai"), CartItems = cartItems };
            //Action
            var result = cartRepository.Add(cart);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetCartByIdPassTest()
        {
            Cart cart = cartRepository.GetByKey(0);
            Assert.IsNotNull(cart);
        }

        [Test]
        public void GetProductByIdFailTest()
        {
            Cart cart = cartRepository.GetByKey(1);
            Assert.IsNull(cart);
        }

        [Test]
        public void DeleteCartByIdPassTest()
        {
            Cart cart = cartRepository.Delete(0);
            Assert.IsNotNull(cart);
        }

        [Test]
        public void DeleteCartByIdFailTest()
        {
            Cart cart = cartRepository.Delete(1);
            Assert.IsNull(cart);
        }

        [Test]
        public void UpdateCartByIdPassTest()
        {
            List<CartItem> cartItems = new List<CartItem>();
            Cart cart = new Cart() { Id = 0, CustomerId = 1, Customer = new Customer(0, "Pavithra", "978675644", "no.5 guru nagar, chennai"), CartItems = cartItems };
            Cart updatedCart = cartRepository.Update(cart);
            Assert.IsNotNull(updatedCart);
        }

        [Test]
        public void UpdtaeProductByIdFailTest()
        {
            List<CartItem> cartItems = new List<CartItem>();
            Cart cart = new Cart() { Id = 2, CustomerId = 2, Customer = new Customer(0, "Pavi", "97866464", "no.5 guru nagar, chennai"), CartItems = cartItems };
            Cart updatedCart = cartRepository.Update(cart);
            Assert.IsNull(updatedCart);
        }

        [Test]
        public void GetAllCartsPassTest()
        {
            List<Cart> cartList = (List<Cart>)cartRepository.GetAll();
            Assert.IsNotEmpty(cartList);
        }

        [Test]
        public void GetAllCartsFailTest()
        {
            List<Cart> products = (List<Cart>)cartRepository.GetAll();
            Assert.IsEmpty(products);
        }
    }
}
