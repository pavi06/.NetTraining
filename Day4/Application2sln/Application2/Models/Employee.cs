using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Models
{
    class Employee
    {
        // int id;
        //public int GetId()
        //{
        //    return id;
        //}
        //public void PutId(int eid)
        //{
        //    id = eid;
        //}

        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}

        //Arrow function
        //public int Id
        //{
        //    get => id;
        //    set => id = value;
        //}

        //property - variable (private) and get, set will be public
        //set and return the value as such.
        public int Id { get; private set; }
        double salary;
        public string Name { get; set; }

        //if any processing needed, can use this method.
        public double Salary
        {
            set
            {
                salary = value;
            }
            get
            {
                return (salary - (salary * 10 / 100));
            }
        }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public Employee() { }

        public Employee(int id) { 
            Id = id;
        }

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="name">employee name as string</param>
        /// <param name="salary">employee salary as string</param>
        /// <param name="dateOfBirth">dob</param>
        /// <param name="email">email</param>
        public Employee(int id, string name, double salary, DateTime dateOfBirth, string email) : this(id)
        {
            Name = name;
            Salary = salary;
            DateOfBirth = dateOfBirth;
            Email = email;
        }

        
        public void PrintEmployeeDetails()
        {
            Console.WriteLine($"Employee Id\t:\t{Id}");
            Console.WriteLine($"Employee name\t:\t{Name}");
            Console.WriteLine($"Employee Date Of Birth\t:\t{DateOfBirth}");
            Console.WriteLine($"Employee Salary\t:\tRs.{Salary}");
            Console.WriteLine($"Employee Email\t:\t{Email}");
        }
        /// <summary>
        /// Displays the work done in the duration
        /// </summary>
        /// <param name="hours">Hors required for work</param>
        /// <returns>Message on hours worked</returns>
        public string Work(int hours)
        {
            Console.WriteLine("Works");
            return $"Done work for {hours} Hours";
        }

        //public void Work()
        //{
        //    Console.WriteLine("Employee Works");
        //}
    }
}
