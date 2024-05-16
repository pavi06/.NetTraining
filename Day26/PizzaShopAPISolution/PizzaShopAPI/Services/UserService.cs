using EmployeeRequestTrackerAPI.Exceptions;
using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interface;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaShopAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Customer> _customerRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Customer> customerRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _customerRepo = customerRepo;
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
                var customer = await _customerRepo.Get(loginDTO.UserId);
                LoginReturnDTO loginReturnDTO = MapCustomerToLoginReturn(customer);
                return loginReturnDTO;
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

        public async Task<CustomerReturnDTO> Register(CustomerDTO customerDTO)
        {
            Customer customer = null;
            User user = null;
            try
            {
                customer = customerDTO;
                user = MapCustomerDTOToUser(customerDTO);
                customer = await _customerRepo.Add(customer);
                if(customer != null)
                {
                    user.CustId = customer.CustId;
                    user = await _userRepo.Add(user);
                    CustomerReturnDTO customerAdded = new CustomerReturnDTO(customer.CustId, customer.CustName, customer.CustPhone, customer.Address, customer.City);
                    return customerAdded;
                }
                throw new ObjectAlreadyExistsException("User Already exists!");
            }
            catch (ObjectAlreadyExistsException e) { throw; }
            catch (Exception) { }
            if (customer != null)
                await RevertCustomerInsert(customer);
            if (user != null && customer == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private LoginReturnDTO MapCustomerToLoginReturn(Customer customer)
        {
            LoginReturnDTO loggedUserDTO = new LoginReturnDTO();
            loggedUserDTO.CustID = customer.CustId;
            loggedUserDTO.Token = _tokenService.GenerateToken(customer);
            return loggedUserDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.CustId);
        }

        private async Task RevertCustomerInsert(Customer customer)
        {
            await _customerRepo.Delete(customer.CustId);
        }

        private User MapCustomerDTOToUser(CustomerDTO customerDTO)
        {
            User user = new User();
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(customerDTO.Password));
            return user;
        }
    }
}
