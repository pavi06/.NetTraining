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
            cartItems.Add(new CartItem(0, 0, new Product(1, "Stick Pen Box", 240.0, "Stationary", 40), 2, 480,5.0, new DateTime(2024, 05, 12)));
            Cart cart = new Cart() { CustomerId = 1, Customer = new Customer(1, "Pavi", "78786756456", "no.3 nehru street, chennai"), CartItems = cartItems };
            cartRepository.Add(cart);
            cart = new Cart() { CustomerId = 2, Customer = new Customer(2, "Pavi", "78786756456", "no.3 nehru street, chennai"), CartItems = new List<CartItem>() };
            cartRepository.Add(cart);
            cartService = new CartBL(cartRepository);
        }

        [Test]
        public void AddCartPassTest()
        {
            //Arrange
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem(0, 0, new Product(0, "Stick Pen Box", 240.0, "Stationary", 40), 2, 480,5, new DateTime(2024, 05, 12)));
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

        [Test]
        public void GetCartItemsByCartIdPassTest()
        {
            var cartItems = cartService.GetCartItemsByCartId(1);
            Assert.IsNotNull(cartItems);
        }

        [Test]
        public void GetCartItemsByCartIdFailTest()
        {
            var exception = Assert.Throws<NoObjectsAvailableException>(() => cartService.GetCartItemsByCartId(2));
            //Assert
            Assert.AreEqual($"No Items where added to the cart", exception.Message);
        }

        [Test]
        public void GetAllCartItemsWithDiscountPassTest()
        {
            var items = cartService.GetAllCartItemsWithDiscount(1);
            Assert.IsNotNull(items);    
        }

        [Test]
        public void GetAllCartItemsWithDiscountExceptionTest()
        {
            var exception = Assert.Throws<NoObjectsAvailableException>(() => cartService.GetAllCartItemsWithDiscount(2));
            //Assert
            Assert.AreEqual($"No Items where added to the cart", exception.Message);
        }

        [Test]
        public void DeleteCartItemByCutsomerIdAndProductIdPassTest()
        {
            var cartItem = cartService.DeleteCartItemByCutsomerIdAndProductId(1, 1);
            Assert.IsNotNull(cartItem);
        }
        [Test]
        public void DeleteCartItemByCutsomerIdAndProductIdExceptionTest()
        {
            var exception = Assert.Throws<NullValueException>(() => cartService.DeleteCartItemByCutsomerIdAndProductId(2, 1));
            //Assert
            Assert.AreEqual("Your Cart is Empty!", exception.Message);
        }

        [Test]
        public void GetCartByCustomerIdPassTest()
        {
            var cart = cartService.GetCartByCustomerId(1);
            Assert.IsNotNull(cart);
        }

        [Test]
        public void GetCartByCustomerIdFailTest()
        {
            var cart = cartService.GetCartByCustomerId(2);
            Assert.AreEqual(cart.Id,2);
        }

        [Test]
        public void GetAllCartPassTest()
        {
            var carts = cartService.GetAllCarts();
            Assert.IsNotNull(carts);
        }

        [Test]
        public void GetShippingChargesPassTest()
        {
            var charge = cartService.GetShippingCharges(1500);
            Assert.AreEqual(0,charge);
        }
        [Test]
        public void GetShippingCharges2PassTest()
        {
            var charge = cartService.GetShippingCharges(98);
            Assert.AreEqual(100, charge);
        }

        [Test]
        public void GetDiscountAmountPassTest()
        {
            var charge = cartService.GetDiscountAmount(3,1500);
            Assert.AreEqual(1425, charge);
        }
        [Test]
        public void GetDiscountAmount2PassTest()
        {
            var charge = cartService.GetDiscountAmount(2, 1500);
            Assert.AreEqual(1500, charge);
        }

        [Test]
        public void GetDiscountPercentPassTest()
        {
            var charge = cartService.GetDiscountPercent(3, 1500);
            Assert.AreEqual(5, charge);
        }
        [Test]
        public void GetDiscountPercent2PassTest()
        {
            var charge = cartService.GetDiscountPercent(2, 1500);
            Assert.AreEqual(0, charge);
        }

        [Test]
        public void GetCustomerIdByCartIdPassTes()
        {
            int id = cartService.GetCustomerIdByCartId(1);
            Assert.AreEqual(1,id);
        }

        [Test]
        public void GetTotalAmountOfCartItemsPassTes()
        {
            double amount = cartService.GetTotalAmountOfCartItems(1);
            Assert.AreEqual(912,amount);
        }
        [Test]
        public void GetCuatomerBycartIdPassTest()
        {
            var cust = cartService.GetCustomerByCartId(1);
            Assert.IsNotNull(cust);
        }

        [Test]
        public void GetCustomerBycartIdExceptionTest()
        {
            var exception = Assert.Throws<ObjectNotAvailableException>(() => cartService.GetCustomerByCartId(4));
            Assert.AreEqual($"Cart with id - 4 not Available!", exception.Message);
        }

        [Test]
        public void GetCartItemsCountPassTest()
        {
            int count = cartService.GetCartItemsCount(1);
            Assert.AreEqual (1, count); 
        }

        [Test]
        public void GetCartItemsCountExceptionTest()
        {
            var exception = Assert.Throws<NoObjectsAvailableException>(() => cartService.GetCartItemsCount(2));
            Assert.AreEqual("No Items where added to the cart", exception.Message);
        }
    }
}
