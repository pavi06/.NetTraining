using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Repositories;

namespace EmployeeRequestTrackerAPI.Services
{
    public class EmployeeBasicService : IEmployeeBasicService
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeBasicService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }
        public async Task<EmployeeDTO> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.Get()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new ObjectNotAvailableException("Employee not available!");
            EmployeeDTO emp = new EmployeeDTO(employee.Id,employee.Name,employee.DateOfBirth,employee.Phone,employee.Image,employee.Role);
            return emp;

        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var employees = await _repository.Get();
            if (employees.Count() == 0)
                throw new NoObjectsAvailableException("No Employees Available!");
            List<EmployeeDTO> employeesList = new List<EmployeeDTO>();
            foreach(var employee in employees)
            {
                employeesList.Add(new EmployeeDTO(employee.Id, employee.Name, employee.DateOfBirth, employee.Phone, employee.Image, employee.Role));

            }
            return employeesList;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByRole(string role)
        {
            var employees = _repository.Get().Result.Where(e=>e.Role == role);
            if (employees.Count() == 0)
                throw new NoObjectsAvailableException("No Employees Available!");
            List<EmployeeDTO> employeesList = new List<EmployeeDTO>();
            foreach (var employee in employees)
            {
                employeesList.Add(new EmployeeDTO(employee.Id, employee.Name, employee.DateOfBirth, employee.Phone, employee.Image, employee.Role));

            }
            return employeesList;
        }

        public async Task<EmployeeDTO> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                throw new ObjectNotAvailableException("Employee not available!");
            employee.Phone = phoneNumber;
            employee = await _repository.Update(employee);
            EmployeeDTO emp = new EmployeeDTO(employee.Id, employee.Name, employee.DateOfBirth, employee.Phone, employee.Image, employee.Role);
            return emp;
        }

        public async Task<EmployeeDTO> UpdateEmployeeName(int id, string name)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                throw new ObjectNotAvailableException("Employee not available!");
            employee.Name = name;
            employee = await _repository.Update(employee);
            EmployeeDTO emp = new EmployeeDTO(employee.Id, employee.Name, employee.DateOfBirth, employee.Phone, employee.Image, employee.Role);
            return emp;
        }

        public async Task<EmployeeDTO> UpdateEmployeeRole(int id, string role)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                throw new ObjectNotAvailableException("Employee not available!");
            employee.Role = role;
            employee = await _repository.Update(employee);
            EmployeeDTO emp = new EmployeeDTO(employee.Id, employee.Name, employee.DateOfBirth, employee.Phone, employee.Image, employee.Role);
            return emp;
        }
    }
}
