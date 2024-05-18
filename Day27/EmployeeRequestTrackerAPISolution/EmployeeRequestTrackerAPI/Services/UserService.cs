using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;
using System.Security.Cryptography;
using System.Text;
using EmployeeRequestTrackerAPI.Exceptions;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Employee> _employeeRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Employee> employeeRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var employee = await _employeeRepo.Get(loginDTO.UserId);
                if(userDB.Status =="Active")
                {
                    LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(employee);
                    return loginReturnDTO;
                }

                throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<EmployeeDTO> Register(EmployeeRegisterDTO employeeDTO)
        {
            Employee employee = null;
            User user = null;
            try
            {
                employee = new Employee(employeeDTO.Name,employeeDTO.DateOfBirth,employeeDTO.Phone,employeeDTO.Image,employeeDTO.Role);
                user = MapEmployeeUserDTOToUser(employeeDTO);
                employee = await _employeeRepo.Add(employee);
                user.EmployeeId = employee.Id;
                user = await _userRepo.Add(user);
                EmployeeDTO emp = new EmployeeDTO(employee.Id,employee.Name,employee.DateOfBirth,employee.Phone,employee.Image,employee.Role);
                return emp;
            }
            catch (Exception) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);
            if (user != null && employee == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private LoginReturnDTO MapEmployeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {

            await _employeeRepo.Delete(employee.Id);
        }

        private User MapEmployeeUserDTOToUser(EmployeeRegisterDTO employee)
        {
            User user = new User();
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employee.Password));
            return user;
        }

        public async Task<UserActivationDTO> GetUserForActivation(UserActivationDTO user)
        {
            var userRetrived = await _userRepo.Get(user.EmployeeId);
            if (userRetrived != null)
            {
                if (userRetrived.Status == "Active")
                    throw new Exception("User Already Activated!");
                userRetrived.Status = "Active";
                try
                {
                    var updatedUSer = await _userRepo.Update(userRetrived);
                    user.Status = updatedUSer.Status;
                    return user;
                }
                catch (ObjectNotAvailableException e)
                {
                    throw;
                }
            }
            throw new ObjectNotAvailableException("User not available!");

        }

    }
}
