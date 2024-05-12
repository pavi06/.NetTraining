using ERequestTrackerBLLLibrary.CustomExceptions;
using ERequestTrackerBLLLibrary.Exceptions;
using ERequestTrackerDALLibrary;
using ERequestTrackerModelLibrary;

namespace ERequestTrackerBLL1Library
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private readonly IRepository<int, Employee> _repository;
        public Employee LoggedInUser;
        public EmployeeLoginBL()
        {
            IRepository<int, Employee> repo = new EmployeeRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<Employee> Login(Employee employee)
        {
            var emp = await _repository.Get(employee.Id);
            if (emp != null)
            {
                if (emp.Password == employee.Password)
                {
                    LoggedInUser = emp;
                    return LoggedInUser;
                }
                return null;
            }
            throw new ObjectNotAvailableException("User not yet Registered! Register now");
        }

        public async Task<string> Logout()
        {
            LoggedInUser = null;
            return "Logged Out successfully";
        }

        public async Task<Employee> Register(Employee employee)
        {
            var result = await _repository.Add(employee);
            if(result != null) {
                LoggedInUser = result;
                return result;
            }
            throw new ObjectAlreadyExistsException("User is already Registered!");
        }
    }
}
