using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IEmployeeAdminService
    {
        public Task<IList<RequestDTO>> GetAllRequest();
    }
}
