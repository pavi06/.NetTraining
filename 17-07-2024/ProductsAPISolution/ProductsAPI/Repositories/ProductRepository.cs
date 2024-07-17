using Microsoft.EntityFrameworkCore;
using ProductsAPI.Contexts;
using ProductsAPI.CustomExceptions;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;
using System.Numerics;

namespace ProductsAPI.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        protected readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product item)
        {
            try
            {
                if (_context.Products.Any(p => p.ProductName == item.ProductName))
                {
                    throw new ObjectAlreadyExistsException("Product");
                }
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (ObjectAlreadyExistsException e)
            {
                throw;
            }
            catch(Exception e)
            {
                throw;
            }
           
        }

        public async Task<Product> Delete(int key)
        {
            try
            {
                var product = await Get(key);
                _context.Remove(product);
                await _context.SaveChangesAsync(true);
                return product;
            }
            catch (NoSuchObjectAvailableException e)
            {
                throw;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public Task<Product> Get(int key)
        {
            try
            {
                var product = _context.Products.FirstOrDefaultAsync(p => p.ProductId == key);
                if (product == null)
                {
                    throw new NoSuchObjectAvailableException("Product");
                }
                return product;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> Get()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                throw;
            }
    
        }

        public async Task<Product> Update(Product item)
        {
            try
            {
                var product = await Get(item.ProductId);
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return product;
            }
            catch(NoSuchObjectAvailableException e)
            {
                throw;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
