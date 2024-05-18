using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRequestController : ControllerBase
    {
        private readonly IEmployeeRequestService _employeeRequestService;

        public EmployeeRequestController(IEmployeeRequestService employeeRequestService)
        {
            _employeeRequestService = employeeRequestService;

        }

        [Authorize(Roles ="Admin,User")]
        [Route("RaiseRequest")]
        [HttpPost]
        [ProducesResponseType(typeof(RequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RequestReturnDTO>> RaiseRequestControl([FromBody] string requestMessage)
        { 
                try
                {
                var LoggedInUser = Convert.ToInt32(User.FindFirstValue("UserId"));
                var requestRaised = await _employeeRequestService.RaiseRequest(requestMessage, LoggedInUser);
                    return Ok(requestRaised);
                }
                catch (ObjectAlreadyExistsException ex)
                {
                    return BadRequest(new ErrorModel(400, ex.Message));
                }
        }


        [Authorize(Roles = "Admin,User")]
        [Route("GetRequestRaised")]
        [HttpPost]
        [ProducesResponseType(typeof(RequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RequestReturnDTO>> GetRequestControl([FromBody] int id,int userId)
        {
                try
                {
                var LoggedInUser = Convert.ToInt32(User.FindFirstValue("UserId"));
                var requestRaised = await _employeeRequestService.GetRequestRaised(id,LoggedInUser);
                    return Ok(requestRaised);
                }
                catch (ObjectNotAvailableException ex)
                {
                    return NotFound(new ErrorModel(404, ex.Message));
                }
                catch(Exception ex)
                {
                    return NotFound(new ErrorModel(404,ex.Message));
                }
        }

        [Authorize(Roles = "Admin,User")]
        [Route("GetAllRequestRaised")]
        [HttpGet]
        [ProducesResponseType(typeof(List<RequestReturnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<RequestReturnDTO>>> GetAllRequestControl()
        {
                try
                {
                var LoggedInUser = Convert.ToInt32(User.FindFirstValue("UserId"));
                var requestRaised = await _employeeRequestService.GetAllRequestRaisedByEmployee(LoggedInUser);
                    return Ok(requestRaised);
                }
                catch (NoObjectsAvailableException ex)
                {
                    return NotFound(new ErrorModel(404, ex.Message));
                }
        }
    }
}
