using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary;
using ShoppingAppModelLibrary.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLLibrary
{
    public class ProductBL : IProductService
    {
        readonly IRepository<int, Product> _productRepository;
        public static int idCount = 0;

        public ProductBL(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(Product product)
        {
            product.Id = ++idCount;
            var retrivedProduct = _productRepository.Add(product);
            if (retrivedProduct != null)
            {
                return retrivedProduct.Id;
            }
            throw new ObjectAlreadyExistsException("Product");
        }

        public Product DeleteProductById(int id)
        {
            var product = _productRepository.Delete(id);
            if (product != null)
            {
                return product;
            }
            throw new ObjectNotAvailableException($"Product with id - {id} not available!");
        }

        public Product GetProductById(int id)
        {
            var product = _productRepository.GetByKey(id);
            if (product != null)
            {
                return product;
            }
            throw new ObjectNotAvailableException($"Product with id - {id} not available!");
            
        }

        public List<Product> GetAllProduct()
        {
            var productList = _productRepository.GetAll();
            if (productList.Count > 0)
            {
                return productList.ToList();
            }
            throw new NoObjectsAvailableException("No Products Available!");
        }

        public Product UpdateProduct(Product product)
        {
            var updatedProduct = _productRepository.Update(product);
            if (updatedProduct != null)
            {
                return updatedProduct;
            }
            throw new ObjectNotAvailableException($"Product with id - {product.Id} not available!");
        }

        public bool UpdateProductPriceById(int id, double newPrice)
        {
            var product = GetProductById(id);
            product.Price = newPrice;
            var updateProduct = UpdateProduct(product);
            if (updateProduct != null) {
                return true;
            }
            return false;
        }

        public bool UpdateProductQuantityById(int id, int newQuantity)
        {
            var product = GetProductById(id);
            product.QuantityInHand = newQuantity;
            var updateProduct = UpdateProduct(product);
            if (updateProduct != null)
            {
                return true;
            }
            return false;
        }

    }
}
