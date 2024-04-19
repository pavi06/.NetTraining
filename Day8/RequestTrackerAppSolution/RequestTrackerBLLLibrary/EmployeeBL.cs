using RequestTrackerBLLLibrary.CustomExceptions;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        readonly IRepository<int, Employee> _employeeRepository;

        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);
            if (result != null)
            {
                return result.Id;
            }
            throw new EmployeeAlreadyExistsException();
        }

        public Employee DeleteEmployeeById(int id)
        {
            var employee = _employeeRepository.Delete(id);
            if (employee != null)
            {
                return employee;
            }
            throw new EmployeeNotFoundException();
        }

        public List<Employee> GetAllEmployees()
        {
            var employeeList = _employeeRepository.GetAll();
            if (employeeList != null)
            {
                return employeeList;
            }
            throw new NoEmployeesAvailableException();
        }

        public List<Employee> GetEmployeesByAttribute(string attribute, string attributeValue)
        {
            List<Employee> employees = new List<Employee>();
            var employeeList = _employeeRepository.GetAll();
            if (employeeList != null) { 
                if(attribute.ToLower() == "type")
                {
                    foreach (var employee in employeeList)
                    {
                        if (employee.Type == attributeValue)
                        {
                            employeeList.Add(employee);
                        }
                    }
                }
                else if (attribute.ToLower() == "role")
                {
                    foreach (var employee in employeeList)
                    {
                        if (employee.Role == attributeValue)
                        {
                            employeeList.Add(employee);
                        }
                    }
                }
                else
                {
                    throw new InvalidAttributeException();
                }
                if(employees.Count > 0)
                {
                    return employees;
                }
                throw new NoEmployeesAvailableException();
            }
            throw new NoEmployeesAvailableException();
        }

        //public List<Employee> GetAllEmployeesByRole(string role)
        //{
        //    List<Employee> employees = new List<Employee>();
        //    var employeeList = _employeeRepository.GetAll();
        //    if(employeeList != null)
        //    {
        //        foreach (var employee in employeeList)
        //        {
        //            if(employee.Role == role)
        //            {
        //                employeeList.Add(employee);
        //            }
        //        }
        //        if(employees.Count > 0)
        //        {
        //            return employees;
        //        }
        //        throw new NoEmployeesAvailableException();
        //    }            
        //    throw new NoEmployeesAvailableException();
        //}

        //public List<Employee> GetAllEmployeesByType(string type)
        //{
        //    List<Employee> employees = new List<Employee>();
        //    var employeeList = _employeeRepository.GetAll();
        //    if (employeeList != null)
        //    {
        //        foreach (var employee in employeeList)
        //        {
        //            if (employee.Type == type)
        //            {
        //                employeeList.Add(employee);
        //            }
        //        }
        //        if (employees.Count > 0)
        //        {
        //            return employees;
        //        }
        //        throw new NoEmployeesAvailableException();
        //    }
        //    throw new NoEmployeesAvailableException();
        //}

        public List<Employee> GetAllEmployeesOfSameDepartment(string departmentName)
        {
            List<Employee> employeesOfSameDepatment = new List<Employee>();
            var employeeList = _employeeRepository.GetAll();
            if (employeeList != null) { 
                foreach (var employee in employeeList)
                {
                    if(employee.EmployeeDepartment.Name == departmentName)
                    {
                        employeesOfSameDepatment.Add(employee);
                    }
                }
                if(employeesOfSameDepatment.Count>0)
                {
                    return employeesOfSameDepatment;
                }
                throw new NoEmployeesAvailableException(); 
            }
            throw new NoEmployeesAvailableException();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                return employee;
            }
            throw new EmployeeNotFoundException();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var updatedEmployee = _employeeRepository.Update(employee);
            if (updatedEmployee != null)
            {
                return updatedEmployee;
            }
            throw new EmployeeNotFoundException();
        }

        public bool UpdateEmployeeDOBById(int id, DateTime newDob)
        {
            var employee = GetEmployeeById(id);
            employee.DateOfBirth = newDob;
            return UpdateEmployee(employee) != null ? true : false;
        }

        public bool UpdateEmployeeNameById(int id, string employeeNewName)
        {
             var employee = GetEmployeeById(id);
             employee.Name = employeeNewName;
             return UpdateEmployee(employee)!= null ? true : false;
        }

        public bool UpdateEmployeeRoleById(int id, string employeeNewRole)
        {
            var employee = GetEmployeeById(id);
            employee.Role = employeeNewRole;
            return UpdateEmployee(employee) != null ? true : false;
        }

        public bool UpdateEmployeeSalaryById(int id, double newSalary)
        {
            var employee = GetEmployeeById(id);
            employee.Salary = newSalary;
            return UpdateEmployee(employee) != null ? true : false;
        }

        public bool UpdateEmployeeTypeById(int id, string employeeNewType)
        {
            var employee = GetEmployeeById(id);
            employee.Type = employeeNewType;
            return UpdateEmployee(employee) != null ? true : false;
        }
    }
}
