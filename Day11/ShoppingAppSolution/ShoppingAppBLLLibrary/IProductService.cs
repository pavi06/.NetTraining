using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLLibrary
{
    public interface IProductService
    {
        Task<int> AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProduct();
        Task<List<Product>> GetAllProductByAttribute(string attribute , string attributeValue);
        Task<List<Product>> GetAllProductByCategoryAndPriceLimit(string category, double price);
        //List<Product> GetAllProductByDiscount();
        Task<Product> DeleteProductById(int id);
        Task<Product> UpdateProduct(Product product);       
        Task<bool> UpdateProductPriceById(int id, double newPrice);
        Task<bool> UpdateProductQuantityById(int id, int newQuantity);
        Task<List<string>> GetAllProductsName();
        Task<List<string>> GetAllCategoriesAvailable();

    }
}
