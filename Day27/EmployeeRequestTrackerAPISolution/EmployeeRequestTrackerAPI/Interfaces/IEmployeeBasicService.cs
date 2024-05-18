using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IEmployeeBasicService
    {
        public Task<EmployeeDTO> GetEmployeeByPhone(string phoneNumber);
        public Task<EmployeeDTO> UpdateEmployeePhone(int id, string phoneNumber);
        public Task<EmployeeDTO> UpdateEmployeeName(int id, string name);
        public Task<EmployeeDTO> UpdateEmployeeRole(int id, string role);
        public Task<IEnumerable<EmployeeDTO>> GetEmployees();
        public Task<IEnumerable<EmployeeDTO>> GetEmployeesByRole(string role);
    }
}
