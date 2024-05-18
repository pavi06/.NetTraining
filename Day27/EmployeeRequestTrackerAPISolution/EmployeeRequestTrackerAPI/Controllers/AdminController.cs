using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Services;
using System.Security.Claims;


namespace EmployeeRequestTrackerAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmployeeBasicService _employeeBasicService;

        public AdminController(IUserService userService, IEmployeeBasicService employeeBasicService)
        {
            _userService = userService;
            _employeeBasicService = employeeBasicService;
        }


        [HttpPut("UsersForActivation")]
        [ProducesResponseType(typeof(UserActivationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserActivationDTO>> ActivateUser(UserActivationDTO user)
        {
                try
                {
                    UserActivationDTO result = await _userService.GetUserForActivation(user);
                    return Ok(result);
                }
                catch (ObjectNotAvailableException e)
                {
                    return NotFound(new ErrorModel(404, e.Message));
                }
                catch (Exception ex)
                {
                    return BadRequest(new ErrorModel(400, ex.Message));
                }
            
        }

        [HttpGet("GetEmployees")]
        [ProducesResponseType(typeof(IList<EmployeeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<EmployeeDTO>>> Get()
        {

                try
                {
                    var employees = await _employeeBasicService.GetEmployees();
                    return Ok(employees.ToList());
                }
                catch (NoObjectsAvailableException ex)
                {
                    return NotFound(new ErrorModel(404,ex.Message));
                }
  
        }



        [HttpPost("GetEmployeeByRole")]
        [ProducesResponseType(typeof(IList<EmployeeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<EmployeeDTO>>> GetByRole([FromBody] string role)
        {
 
                try
                {
                    var LoggedInUser = Convert.ToInt32(User.FindFirstValue("UserId")); 
                    var employees = _employeeBasicService.GetEmployeesByRole(role).Result.Where( e => e.Id != LoggedInUser);
                    return Ok(employees.ToList());
                }
                catch (NoObjectsAvailableException ex)
                {
                    return NotFound(new ErrorModel(404,ex.Message));
                }
                catch(Exception ex)
                {
                    return NotFound(ex.Message);
                }
  

        }



        [Route("GetEmployeeByPhone")]
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> Get([FromBody] string phone)
        {

                try
                {
                    var employee = await _employeeBasicService.GetEmployeeByPhone(phone);
                    return Ok(employee);
                }
                catch (ObjectNotAvailableException ex)
                {
                    return NotFound(new ErrorModel(404,ex.Message));
                }
   
        }

        [HttpPut("UpdateEmployeeRole")]
        [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> UpdateRole(int id, string role)
        {
                try
                {
                    var employee = await _employeeBasicService.UpdateEmployeeRole(id, role);
                    return Ok(employee);
                }
                catch (ObjectNotAvailableException ex)
                {
                    return NotFound(ex.Message);
                }
        }

    }
}
