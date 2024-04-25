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

        public ProductBL(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(Product product)
        {
        
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

        public List<Product> GetAllProductByAttribute(string attribute, string attributeValue)
        {
            
            var products = GetAllProduct();
            if (attribute.ToLower() == "category")
            {
                var productListByCategory = from p in products
                                            where p.Category.ToLower() == attributeValue.ToLower()
                                            select p;
                if (productListByCategory.Count() > 0)
                    return productListByCategory.ToList();
            }
            else if (attribute.ToLower() == "name") {
                var productListByCategory = from p in products
                                            where p.Name.ToLower() == attributeValue.ToLower()
                                            select p;
                if (productListByCategory.Count() > 0)
                    return productListByCategory.ToList();
            }
            else
            {
                throw new NullValueException("No such item can be found!"); 
            }
            
            throw new NoObjectsAvailableException($"No Products Available under {attributeValue} {attribute}!"); 
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

        public List<Product> GetAllProductByCategoryAndPriceLimit(string category, double price)
        {
            var products = GetAllProductByAttribute("category", category);
            var filteredProducts = from p in products
                                   where p.Price <=price
                                   select p;
            if (filteredProducts.ToList().Count() > 0) { 
                return filteredProducts.ToList();
            }
            throw new NoObjectsAvailableException($"No {category} Available under {price} price!"); ;
        }

        public List<string> GetAllProductsName()
        {
            List<string> productNames = new List<string>();
            var products = GetAllProduct();
            foreach ( var p in products )
            {
                productNames.Add(p.Name);
            }
            if(productNames.Count > 0)
            {
                return productNames;
            }
            throw new NoObjectsAvailableException("No products Available!");
        }

        public List<string> GetAllCategoriesAvailable()
        {
            List<string> catagories = new List<string>();
            var products = GetAllProduct();
            foreach (var p in products)
            {
                catagories.Add(p.Category);
            }
            if (catagories.Count > 0)
            {
                return catagories;
            }
            throw new NoObjectsAvailableException("No products Available!");
        }

        //public List<Product> GetAllProductByDiscount()
        //{
        //    var products = GetAllProduct();
        //    var filteredProducts = from p in products
        //                           where p
        //    throw new NotImplementedException();
        //}
    }
}
