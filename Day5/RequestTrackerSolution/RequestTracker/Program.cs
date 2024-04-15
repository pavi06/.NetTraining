using RequestTrackerLibrary;

namespace RequestTracker
{
    internal class Program
    {

        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }
        void PrintMenu()
        {
            Console.WriteLine("-----------Menu---------------");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee by ID");
            Console.WriteLine("5. Delete Employee by ID");
            Console.WriteLine("0. Exit");
        }
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddEmployee()
        {
            //if (employees[employees.Length - 1] != null)
            //{
            //    Console.WriteLine("Sorry we have reached the maximum number of employees");
            //    return;
            //}
            bool flagToCheckForEmployeeAddition = false;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                    flagToCheckForEmployeeAddition = true;
                }
            }
            if (!flagToCheckForEmployeeAddition) {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }

        }
        void PrintAllEmployees()
        {
            Console.WriteLine("Employees Available");
            bool flagToCheckIfEmployeeAvailable = false;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
                flagToCheckIfEmployeeAvailable = true;
            }
            if (!flagToCheckIfEmployeeAvailable)
            {
                Console.WriteLine("No Employees available");
                return;
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("\nPrint One employee");
            int id = GetIdFromConsole();
            Employee employee = null;
            employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            bool employeeAvailable = false;
            for (int i = 0; i < employees.Length; i++)
            {
                // if ( employees[i].Id == id && employees[i] != null)//Will lead to exception
                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    employeeAvailable = true;
                    break;
                }
            }
            return employee;
        }

        string GetNameFromConsoleAndUpdate()
        {
            string nameToUpdate = string.Empty;
            do {
                Console.WriteLine("Enter the correct name: ");
                nameToUpdate = Console.ReadLine();
            }
            while (nameToUpdate.Any(char.IsDigit));
            return nameToUpdate;
        }

        void UpdateNameOfEmployee(int id) {
            Employee employee = SearchEmployeeById(id);
            Console.WriteLine("\nEmployee Details Before Update");
            PrintEmployee(employee);
            employee.Name = GetNameFromConsoleAndUpdate();
            Console.WriteLine("Employee Detail After Update");
            PrintEmployee(employee);
        }

        void UpdateEmployee() {
            Console.WriteLine("\nEnter the Employee detail for Update");
            int id = GetIdFromConsole();
            UpdateNameOfEmployee(id);
        }

        void DeleteEmployeeById(int id) {
            bool deleted = false;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    Console.WriteLine("Deleted Employee");
                    PrintEmployee(employees[i]);
                    employees[i] = null;
                    deleted = true;
                    break;
                }
            }
            if (!deleted) {
                Console.WriteLine("No such Employee is present");
                return;
            }
        }

        void DeleteEmployee() {
            Console.WriteLine("\nEnter the Employee detail to delete");
            int id = GetIdFromConsole();
            DeleteEmployeeById(id);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}
