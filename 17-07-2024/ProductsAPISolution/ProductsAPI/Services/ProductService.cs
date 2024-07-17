using ProductsAPI.CustomExceptions;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;
using System.Numerics;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        protected readonly IRepository<int, Product> _productRepository;

        public ProductService(IRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }

        #region GetAllProducts
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            try
            {
                List<ProductDTO> productsList = _productRepository.Get().Result.Select(p => new ProductDTO(p.ProductId,p.ImageUrl, p.ProductName, p.Price)).ToList();
                return productsList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region GetProductByID
        public async Task<ProductDTO> GetProduct(int id)
        {
            try
            {
                var product = await _productRepository.Get(id);
                return new ProductDTO (product.ProductId,product.ImageUrl,product.ProductName,product.Price);
            }
            catch(NoSuchObjectAvailableException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
