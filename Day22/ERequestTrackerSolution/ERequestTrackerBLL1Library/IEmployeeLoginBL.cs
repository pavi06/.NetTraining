using ERequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerBLL1Library
{
    public interface IEmployeeLoginBL
    {
        public Task<Employee> Login(Employee employee);
        public Task<Employee> Register(Employee employee);
        public Task<string> Logout();
    }
}
