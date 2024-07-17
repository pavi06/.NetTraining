using Microsoft.AspNetCore.Mvc;
using ProductsAPI.CustomExceptions;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;
using System.Numerics;

namespace ProductsAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        protected readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(List<ProductDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<ProductDTO>>> Get()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products.ToList());
            }
            catch (Exception e)
            {
                return NotFound(new ErrorModel(404, e.Message));
            }
        }

        [HttpPost]
        [Route("GetProduct")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetSingleProduct([FromBody] int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);
                return Ok(product);
            }
            catch (NoSuchObjectAvailableException e)
            {
                return NotFound(new ErrorModel ( 404, e.Message ));
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorModel(404, e.Message));
            }
        }
    }
}
