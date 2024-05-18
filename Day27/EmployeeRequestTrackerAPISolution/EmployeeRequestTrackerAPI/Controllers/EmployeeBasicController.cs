using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{

    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBasicController : ControllerBase
    {
        private readonly IEmployeeBasicService _employeeBasicService;

        public EmployeeBasicController(IEmployeeBasicService employeeService)
        {
            _employeeBasicService = employeeService;
        }


        [HttpPut("UpdateEmployeePhone")]
        [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> UpdatePhone(string phone)
        {
                try
                {
                    var loggedUser = Convert.ToInt32(User.FindFirstValue("UserId"));
                    var employee = await _employeeBasicService.UpdateEmployeePhone(loggedUser, phone);
                    return Ok(employee);
                }
                catch (ObjectNotAvailableException ex)
                {
                    return NotFound(new ErrorModel(404, ex.Message));
                }
        }


        [HttpPut("UpdateEmployeeName")]
        [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> UpdateName(string name)
        {
            try
            {
                var loggedUser = Convert.ToInt32(User.FindFirstValue("UserId"));
                var employee = await _employeeBasicService.UpdateEmployeeName(loggedUser, name);
                return Ok(employee);
            }
            catch (ObjectNotAvailableException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

    }

}
