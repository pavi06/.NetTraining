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
    public class ProductBLTest
    {
        IRepository<int, Product> productRepository;
        IProductService productService;

        [SetUp]
        public void Setup()
        {

            productRepository = new ProductRepository();
            Product product = new Product() { Name = "Painting Canvas", Category = "Stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            productRepository.Add(product);
            product = new Product() { Name = "Sketch box", Category = "Stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            productRepository.Add(product);
            productService = new ProductBL(productRepository);
        }

        [Test]
        public void AddProductPassTest()
        {
            //Arrange
            Product product = new Product() { Name = "Painting Canvas", Category = "Stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            //action
            var addedCustomer = productService.AddProduct(product);
            //Assert
            Assert.IsNotNull(addedCustomer);
        }


        [Test]
        public void AddProductExceptionTest()
        {
            Product product = new Product() { Name = "Painting Canvas", Category = "Stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            //Action
            var exception = Assert.Throws<ObjectAlreadyExistsException>(() => productService.AddProduct(product));
            //Assert
            Assert.AreEqual("Product Already Exists!", exception.Message);
        }

        [Test]
        public void GetProductPassTest()
        {
            //action
            var product = productService.GetProductById(1);
            //Assert
            Assert.IsNotNull(product);
        }

        [Test]
        public void GetProductExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => productService.GetProductById(id));
            //Assert
            Assert.AreEqual($"Product with id - {id} not available!", exception.Message);
        }

        [Test]
        public void DeleteProductPassTest()
        {
            //action
            var product = productService.DeleteProductById(1);
            //Assert
            Assert.IsNotNull(product);
        }

        [Test]
        public void DeleteProductExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => productService.DeleteProductById(id));
            //Assert
            Assert.AreEqual($"Product with id - {id} not available!", exception.Message);
        }


        [Test]
        public void UpdateProductPassTest()
        {
            Product product = productService.GetProductById(1);
            product.Category = "Necessity";
            var updatedProduct = productService.UpdateProduct(product);
            Assert.IsNotNull(updatedProduct);

        }
        [Test]
        public void UpdateProductExceptionTest()
        {
            Product product = new Product() { Id=3,Name = "Painting Canvas", Category = "Stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            var exception = Assert.Throws<ObjectNotAvailableException>(() => productService.UpdateProduct(product));
            //Assert
            Assert.AreEqual($"Product with id - {product.Id} not available!", exception.Message);
        }

        [Test]
        public void UpdateProductPricePassTest()
        {
            Product product = productService.GetProductById(1);
            product.Price = 450.89; 
            var updatedProduct = productService.UpdateProduct(product);
            Assert.IsNotNull(updatedProduct);

        }
        [Test]
        public void UpdateProductPriceExceptionTest()
        {
            Product product = productService.GetProductById(1);
            product.Price = 450.89; 
            var exception = Assert.Throws<ObjectNotAvailableException>(() => productService.UpdateProduct(product));
            //Assert
            Assert.AreEqual($"Product with id - {product.Id} not available!", exception.Message);
        }

        [Test]
        public void UpdateProductQuantityPassTest()
        {
            Product product = productService.GetProductById(1);
            product.QuantityInHand = 450;
            var updatedProduct = productService.UpdateProduct(product);
            Assert.IsNotNull(updatedProduct);

        }
        [Test]
        public void UpdateProductQuantityExceptionTest()
        {
            Product product = productService.GetProductById(3);
            product.QuantityInHand = 45;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => productService.UpdateProduct(product));
            //Assert
            Assert.AreEqual($"Product with id - {product.Id} not available!", exception.Message);
        }

    }
}
