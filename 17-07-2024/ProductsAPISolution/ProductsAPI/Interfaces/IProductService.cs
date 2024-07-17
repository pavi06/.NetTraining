using ProductsAPI.Models;

namespace ProductsAPI.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductDTO>> GetAllProducts();
        public Task<ProductDTO> GetProduct(int id);
    }
}
