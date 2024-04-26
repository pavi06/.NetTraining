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
    public class CartItemBLTests
    {

        IRepository<int, CartItem> cartItemRepository;
        IRepository<int, Cart> cartRepository;
        ICartItemService cartItemService;

        [SetUp]
        public void Setup()
        {

            cartItemRepository = new CartItemRepository();
            cartRepository = new CartRepository();
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            cartItemRepository.Add(cartItem);
            cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            cartItemRepository.Add(cartItem);
            cartItemService = new CartItemBL(cartItemRepository,cartRepository);
        }

        [Test]
        public void AddCartItemPassTest()
        {
            //Arrange
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            //action
            var addedCustomer = cartItemService.AddCartItem(cartItem);
            //Assert
            Assert.IsNotNull(addedCustomer);
        }


        [Test]
        public void CartItemAlreadyExistsExceptionTest()
        {
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            //Action
            var exception = Assert.Throws<ObjectAlreadyExistsException>(() => cartItemService.AddCartItem(cartItem));
            //Assert
            Assert.AreEqual("CartItem Already Exists!", exception.Message);
        }

        [Test]
        public void GetCartItemtPassTest()
        {
            //action
            var cartItem = cartItemService.GetCartItemById(1);
            //Assert
            Assert.IsNotNull(cartItem);
        }

        [Test]
        public void CartItemNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => cartItemService.GetCartItemById(id));
            //Assert
            Assert.AreEqual($"CartItem with id - {id} not Available!", exception.Message);
        }

        [Test]
        public void DeleteCartItemPassTest()
        {
            //action
            var cartItem = cartItemService.DeleteCartItem(1);
            //Assert
            Assert.IsNotNull(cartItem);
        }

        [Test]
        public void DeleteCartItemNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => cartItemService.DeleteCartItem(id));
            //Assert
            Assert.AreEqual($"CartItem with id - {id} not Available!", exception.Message);
        }


        [Test]
        public void UpdateCartItemPassTest()
        {
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            var updatedProduct = cartItemService.UpdateCartItem(cartItem);
            Assert.IsNotNull(updatedProduct);

        }
        [Test]
        public void UpdateCartItemExceptionTest()
        {
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            var exception = Assert.Throws<ObjectNotAvailableException>(() => cartItemService.UpdateCartItem(cartItem));
            //Assert
            Assert.AreEqual($"CartItem with id - {cartItem.Id} not available!", exception.Message);
        }

        [Test]
        public void UpdateQuantityPassTest()
        {
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 50), 2, 90,0, new DateTime(2024, 07, 03));
            var updatedCart = cartItemService.UpdateCartItem(cartItem);
            Assert.IsNotNull(updatedCart);

        }
        [Test]
        public void UpdateQuantityExceptionTest()
        {
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            var exception = Assert.Throws<ObjectNotAvailableException>(() => cartItemService.UpdateCartItem(cartItem));
            //Assert
            Assert.AreEqual($"CartItem with id - {cartItem.Id} not available!", exception.Message);
        }
    }
}
