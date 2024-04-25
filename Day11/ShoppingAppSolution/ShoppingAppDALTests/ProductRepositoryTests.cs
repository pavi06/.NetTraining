using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary;

namespace ShoppingAppDALTests
{
    public class ProductRepositoryTests
    {
        IRepository<int, Product> productRepository;        
        
        [SetUp]
        public void Setup()
        {
            //productRepository = new ProductRepository();
            //Product product = new Product() { Name = "Painting Canvas", Category = "Stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            //productRepository.Add(product);
        }

        [Test]
        public void AddProductSuccessTest()
        {
            //Arrange 
            Product product = new Product() { Name = "Camel Paint", Category = "Stationary" ,Price = 650.0, Image = "https://demoWaterBottle/w1" , QuantityInHand = 40 };
            //Action
            var result = productRepository.Add(product);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddProductFailTest()
        {
            //Arrange 
            Product product = new Product() { Name = "Painting Canvas", Category = "Stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            //Action
            var result = productRepository.Add(product);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetProductByIdPassTest() { 
            Product product = productRepository.GetByKey(0);
            Assert.IsNotNull(product);
        }

        [Test]
        public void GetProductByIdFailTest()
        {
            Product product = productRepository.GetByKey(3);
            Assert.IsNull(product);
        }

        [Test]
        public void DeleteProductByIdPassTest()
        {
            Product product = productRepository.Delete(0);
            Assert.IsNotNull(product);
        }

        [Test]
        public void DeleteProductByIdFailTest()
        {
            Product product = productRepository.Delete(3);
            Assert.IsNull(product);
        }

        [Test]
        public void UpdateProductByIdPassTest()
        {
            Product product = new Product() { Id = 1, Name = "Painting Canvas", Category = "Stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 45 };
            Product updatedProduct = productRepository.Update(product);
            Assert.IsNotNull(product);
        }

        [Test]
        public void UpdateProductByIdFailTest()
        {
            Product product = new Product() { Id = 2, Name = "Painting Canvas", Category = "Stationary", Price = 350.0, Image = "https://demoWaterBottle/w1", QuantityInHand = 40 };
            Product updatedProduct = productRepository.Update(product);
            Assert.IsNull(updatedProduct);
        }

        [Test]
        public void GetAllProductsPassTest()
        {
            var products = productRepository.GetAll().ToList();
            Assert.IsNotEmpty(products);
        }

        [Test]
        public void GetAllProductsFailTest()
        {
            var products =productRepository.GetAll().ToList();
            Assert.IsEmpty(products);
        }


    }
}