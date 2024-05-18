using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeRequestTrackerAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using EmployeeRequestTrackerAPI.Services;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRequestController : ControllerBase
    {

        private readonly IEmployeeAdminService _employeeAdminService;

        public AdminRequestController(IEmployeeAdminService employeeAdminService)
        {
            _employeeAdminService = employeeAdminService;
        }


        [HttpGet("GetAllRequestRaised")]
        [ProducesResponseType(typeof(IList<RequestDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<RequestDTO>>> GetRequest()
        {

            try
            {
                var requests = await _employeeAdminService.GetAllRequest();
                return Ok(requests.ToList());
            }
            catch (NoObjectsAvailableException ex)
            {
                return NotFound(new ErrorModel(404,ex.Message));
            }
        }
           
    }
}
