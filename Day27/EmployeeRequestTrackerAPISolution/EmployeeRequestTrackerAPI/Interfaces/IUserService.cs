using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<EmployeeDTO> Register(EmployeeRegisterDTO employeeDTO);

        public Task<UserActivationDTO> GetUserForActivation(UserActivationDTO user);
    }
}
