using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDALTests
{
    public class CartItemRepositoryTests
    {
        IRepository<int, CartItem> cartItemRepository;

        [SetUp]
        public void Setup()
        {
            cartItemRepository = new CartItemRepository();
            CartItem cartItem = new CartItem(1,1,1, new Product(1, "Apple", 45.0, "Food", 10),2,90, 0,new DateTime(2024, 07, 03));
            cartItemRepository.Add(cartItem);
        }

        [Test]
        public void AddCartItemSuccessTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            //Action
            var result = cartItemRepository.Add(cartItem);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddCartItemFailTest()
        {
            //Arrange 
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            //Action
            var result = cartItemRepository.Add(cartItem);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetCartItemByIdPassTest()
        {
            CartItem cartItem = cartItemRepository.GetByKey(1);
            Assert.IsNotNull(cartItem);
        }

        [Test]
        public void GetCartItemByIdFailTest()
        {
            CartItem cartItem = cartItemRepository.GetByKey(3);
            Assert.IsNull(cartItem);
        }

        [Test]
        public void DeleteCartItemByIdPassTest()
        {
            CartItem cartItem = cartItemRepository.Delete(1);
            Assert.IsNotNull(cartItem);
        }

        [Test]
        public void DeleteCartItemByIdFailTest()
        {
            CartItem cartItem = cartItemRepository.Delete(3);
            Assert.IsNull(cartItem);
        }

        [Test]
        public void UpdateCartItemByIdPassTest()
        {
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            CartItem updatedCartItem = cartItemRepository.Update(cartItem);
            Assert.IsNotNull(updatedCartItem);
        }

        [Test]
        public void UpdateCartItemByIdFailTest()
        {
            CartItem cartItem = new CartItem(1, 1, 1, new Product(1, "Apple", 45.0, "Food", 10), 2, 90,0, new DateTime(2024, 07, 03));
            CartItem updatedCartItem = cartItemRepository.Update(cartItem);
            Assert.IsNull(updatedCartItem);
        }

        [Test]
        public void GetAllCartItemPassTest()
        {
            List<CartItem> products = (List<CartItem>)cartItemRepository.GetAll();
            Assert.IsNotEmpty(products);
        }

        [Test]
        public void GetAllCartItemFailTest()
        {
            List<CartItem> products = (List<CartItem>) cartItemRepository.GetAll();
            Assert.IsEmpty(products);
        }
    }
}
