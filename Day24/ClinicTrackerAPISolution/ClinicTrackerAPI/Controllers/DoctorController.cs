using ClinicTrackerAPI.Exceptions;
using ClinicTrackerAPI.Interfaces;
using ClinicTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        protected readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService) { 
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get()
        {
            try
            {
                var doctors = await _doctorService.GetDoctors();
                return Ok(doctors.ToList());
            }
            catch (NoDoctorsAvailableException e)
            {
                return NotFound(e.Message);
            }
        }

        [Route("DoctorsBySpeciality")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get(string speciality)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsBySpeciality(speciality);
                return Ok(doctors.ToList());
            }
            catch (NoDoctorsAvailableException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctorExp(int id, int experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(id, experience);
                return Ok(doctor);
            }
            catch (NoDoctorsAvailableException e)
            {
                return NotFound(e.Message);
            }
        }


    }
}
