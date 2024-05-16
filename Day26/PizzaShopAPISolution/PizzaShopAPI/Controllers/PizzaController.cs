using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopAPI.Interface;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {

        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [Authorize]
        [Route("GetAllPizza")]
        [HttpGet]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Pizza>>> GetAll()
        {
            try
            {
                var pizza = await _pizzaService.GetAllPizza();
                return Ok(pizza.ToList());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [Authorize]
        [Route("GetAllAvailablePizza")]
        [HttpGet]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Pizza>>> Get()
        {
            try
            {
                var pizza = await _pizzaService.GetAllAvailablePizza();
                return Ok(pizza.ToList());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
