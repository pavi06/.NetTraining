using Application2.Models;

namespace Application2
{
    internal class Program
    {
        Employee CreateEmployeeByTakingDetailsFromConsole(int id)
        {
            Employee employee = new Employee(id);
            Console.WriteLine("Please enter the employee name : ");
            employee.Name = Console.ReadLine();
            Console.WriteLine("Please enter the employee Date of Birth : ");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the employee salary : ");
            double salary;
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            employee.Salary = salary;
            Console.WriteLine("Please enter the employee email : ");
            employee.Email = Console.ReadLine();
            return employee;
        }

        static void Main(string[] args)
        {
            //Employee employee1 = new Employee();
            //employee1.Name = "Shiva";
            //employee1.Salary = 40000;
            //employee1.DateOfBirth = new DateTime(2002, 1, 1);
            //employee1.Email = "shiva@acorp.com";


            //Employee employee2 = new Employee
            //{
            //    Name = "Pavi",
            //    DateOfBirth = new DateTime(2002, 3, 6),
            //    Email = "pavi@abccorp.com",
            //    Salary = 30000
            //};

            //Employee employee3 = new Employee(3, "viji", 40000, new DateTime(2000, 03, 08), "viji@gmail.com");
            //Console.WriteLine($"{employee3.Name} - Salary : "+ employee3.Salary);
            //Console.WriteLine($"{employee2.Name} - Salary : " + employee2.Salary);
            //employee1.Work();
            //employee3.PrintEmployeeDetails();

            Program program = new Program();
            //creating array of reference objects(employee type).
            Employee[] employees = new Employee[1];
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = program.CreateEmployeeByTakingDetailsFromConsole(1 + i);
            }
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i].PrintEmployeeDetails();
            }
        }
    }
}
