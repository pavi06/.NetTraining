using ERequestTrackerApp;
using ERequestTrackerBLL1Library;
using ERequestTrackerBLLLibrary;
using ERequestTrackerDALLibrary;
using ERequestTrackerModelLibrary;
using System.ComponentModel.Design;
using System.Data;
using System.Xml.Linq;

namespace ERequestTrackerApp
{
    internal class Program
    {
        async Task<Employee> EmployeeLoginAsync(int username, string password, IEmployeeLoginBL employeeLoginBl)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            var result = await employeeLoginBl.Login(employee);
            if (result != null)
                await Console.Out.WriteLineAsync("Login Success");
            else
                Console.Out.WriteLine("Invalid username or password");
            return result;
        }
        async Task<Employee> GetLoginDeatils(IEmployeeLoginBL employeeLoginBl)
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            return await EmployeeLoginAsync(id, password, employeeLoginBl);
        }

        async Task<Employee> EmployeeRegisterAsync(string name, string password, IEmployeeLoginBL employeeLoginBl)
        {
            Employee employee = new Employee() { Name = name, Password = password, Role = "user" };
            var result = await employeeLoginBl.Register(employee);
            if (result != null)
            {
                await Console.Out.WriteLineAsync("Registration Successfull!");
                return result;
            }
            else
            {
                Console.Out.WriteLine("Oops! Registration not successful ...Try Again later!");
            }
            return null;
        }

        async Task<Employee> GetRegisterDeatils(IEmployeeLoginBL employeeLoginBl)
        {
            await Console.Out.WriteLineAsync("Please Enter Employee Name");
            string name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Please Enter Employee password");
            string password = Console.ReadLine() ?? "";
            return await EmployeeRegisterAsync(name, password, employeeLoginBl);
        }

        async Task<int> Menu()
        {
            await Console.Out.WriteLineAsync("----------Welcome to Request Tracker Application--------\n1. Already a User?? Login Now..\n2.New to the system ?? Register Now..");
            int userChoice;
            while(!int.TryParse(Console.ReadLine(), out userChoice) && userChoice!=1 && userChoice!=2)
            {
                Console.WriteLine("Enter your choice : ");
            }
            return userChoice; 
        }

        public async Task CheckUserAndDisplayMenu(Employee user, IEmployeeLoginBL employeeLoginBl)
        {
            if (user.Role.ToLower() == "user")
            {
                EmployeeMain employeeMain = new EmployeeMain();
                employeeMain.Starter(user, employeeLoginBl);
            }
            else
            {
                EmployeeAdminMain employeeAdminMain = new EmployeeAdminMain();
                employeeAdminMain.Starter(user, employeeLoginBl);
            }
        }

        static async Task Main(string[] args)
        {
            try
            {
                Program program = new Program();
                IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
                var input = program.Menu().Result;
                Employee user;
                if (input == 1)
                {
                    user = await program.GetLoginDeatils(employeeLoginBL);
                    if (user != null)
                    {
                        Console.WriteLine($"Logged In user : {user.Id}");
                        program.CheckUserAndDisplayMenu(user, employeeLoginBL);
                    }
                    else
                        Console.WriteLine("Not LoggedIn");
                }
                else
                {
                    user = await program.GetRegisterDeatils(employeeLoginBL);
                    if (user != null)
                    {
                        Console.WriteLine($"Registered user : {user.Id}");
                        program.CheckUserAndDisplayMenu(user, employeeLoginBL);
                    }
                    else
                        Console.WriteLine("Not Registered");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         }
    }
}
