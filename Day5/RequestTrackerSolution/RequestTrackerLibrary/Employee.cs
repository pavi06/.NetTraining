using System;
using System.Xml.Linq;

namespace RequestTrackerLibrary
{
    public class Employee
    {
        int age;
        DateTime dob;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public double Salary { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
        }
        public Employee(int id, string name, DateTime dateOfBirth, double salary)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }

        string GetStringInputFromConsole()
        {
            bool flag = false;
            string name = "";
            do
            {
                if (flag)
                {
                    Console.WriteLine("Invalid input. Please enter the proper name.");
                }
                else
                {
                    Console.WriteLine("Please enter the Name: ");
                    flag = true;
                }
                name = Console.ReadLine();
            }
            while (name.Any(char.IsDigit));
            return name;
        }

        public void BuildEmployeeFromConsole()
        {
            //Console.WriteLine("Please enter the Name");
            Name = GetStringInputFromConsole();            
            Console.WriteLine("Please enter the Date of birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the Basic Salary");
            double sal;
            while (!double.TryParse(Console.ReadLine(), out sal))
                Console.WriteLine("Invalid value. Enter the salary again.");
            Salary = sal;
        }

        public void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
            Console.WriteLine("Employee Salary : Rs." + Salary);
        }
    }
}
