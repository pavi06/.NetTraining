using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLLibrary
{
    internal interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees();
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployeeById(int id);
        List<Employee> GetEmployeesByAttribute(string attribute, string attributeValue);

        //List<Employee> GetAllEmployeesByRole(string role);
        //List<Employee> GetAllEmployeesByType(string type);
        bool UpdateEmployeeNameById(int id, string employeeNewName);
        List<Employee> GetAllEmployeesOfSameDepartment(string departmentName);
        bool UpdateEmployeeSalaryById(int id, double newSalary);
        bool UpdateEmployeeDOBById(int id, DateTime newDob);
        bool UpdateEmployeeTypeById(int id, string employeeNewType);
        bool UpdateEmployeeRoleById(int id, string employeeNewRole);

    }
}
