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
            Product product = new Product() { Name = "Painting Canvas", Category = "stationary", Price = 300, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            productRepository.Add(product);
            product = new Product() { Name = "Sketch box", Category = "stationary", Price = 30, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            productRepository.Add(product);
            productService = new ProductBL(productRepository);
        }

        [Test]
        public void AddProductPassTest()
        {
            //Arrange
            Product product = new Product() { Name = "Painting Canvas", Category = "stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            //action
            var addedCustomer = productService.AddProduct(product);
            //Assert
            Assert.IsNotNull(addedCustomer);
        }


        [Test]
        public void AddProductExceptionTest()
        {
            Product product = new Product() { Name = "Painting Canvas", Category = "stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
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
            Product product = productService.GetProductById(3);
            product.Category = "Food";
            var exception = Assert.Throws<ObjectNotAvailableException>(() => productService.UpdateProduct(product));
            //Assert
            Assert.AreEqual($"Product with id - {product.Id} not available!", exception.Message);
        }

        [Test]
        public void UpdateProductPricePassTest()
        {
            var result = productService.UpdateProductPriceById(1, 600.0);
            Assert.IsTrue(result);

        }
        [Test]
        public void UpdateProductPriceExceptionTest()
        {
            var exception = Assert.Throws<ObjectNotAvailableException>(() => productService.UpdateProductPriceById(1, 600.0));
            //Assert
            Assert.AreEqual($"Product with id - 3 not available!", exception.Message);
        }

        [Test]
        public void UpdateProductQuantityPassTest()
        {
            var result = productService.UpdateProductQuantityById(1,5);
            Assert.IsTrue(result);

        }
        [Test]
        public void UpdateProductQuantityExceptionTest()
        {
            var exception = Assert.Throws<ObjectNotAvailableException>(() => productService.UpdateProductQuantityById(4, 5));
            //Assert
            Assert.AreEqual($"Product with id - 4 not available!", exception.Message);
        }

        [Test]
        public void GetAllProductByCategoryAndPriceLimitPassTest()
        {
            var products = productService.GetAllProductByCategoryAndPriceLimit("stationery", 30);
            Assert.IsNotNull(products);
        }

        [Test]
        public void GetAllProductByCategoryAndPriceLimitExceptionTest()
        {
            string category = "stationery";
            double price = 350;
            var exception = Assert.Throws<NoObjectsAvailableException>(() => productService.GetAllProductByCategoryAndPriceLimit(category, price));
            Assert.AreEqual("No Products Available under stationery category!", exception.Message);
        }

        [Test]
        public void GetAllProductByAttributePassTest()
        {
            var products = productService.GetAllProductByAttribute("category", "stationery");
            Assert.IsNotNull(products);
        }

        [Test]
        public void GetAllProductByAttributeExceptionTest()
        {
            string attributeValue = "stationery";
            string attribute = "category";
            var exception = Assert.Throws<NoObjectsAvailableException>(() => productService.GetAllProductByAttribute(attribute,attributeValue));
            Assert.AreEqual($"No Products Available under {attributeValue} {attribute}!", exception.Message);
        }

        [Test]
        public void GetAllProductsPassTest()
        {
            var products = productService.GetAllProduct();
            Assert.IsNotNull(products);
        }

        [Test]
        public void GetAllProductsFailTest()
        {
            var products = productService.GetAllProduct();
            Assert.IsNull(products);
        }

        [Test]
        public void GetAllProductsNamePassTest()
        {
            var productNames = productService.GetAllProductsName();
            Assert.IsNotNull(productNames);
        }

        [Test]
        public void GetAllProductNameExceptionTest()
        {
            var exception = Assert.Throws<NoObjectsAvailableException>(() => productService.GetAllProductsName());
            Assert.AreEqual("No products Available!", exception.Message);
        }

        [Test]
        public void GetAllCategoriesAvailablePassTest()
        {
            var categories = productService.GetAllCategoriesAvailable();
            Assert.IsNotNull(categories);
        }

        [Test]
        public void GetAllCategoriesAvailableExceptionTest()
        {
            var exception = Assert.Throws<NoObjectsAvailableException>(() => productService.GetAllCategoriesAvailable());
            Assert.AreEqual("No products Available!", exception.Message);
        }

    }
}
