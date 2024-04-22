namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        public Department EmployeeDepartment { get; set; }
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
        public string Type { get; set; }
        public string Role { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            Type = string.Empty;
            Role = "Employee";
        }
        public Employee(int id, string name, DateTime dateOfBirth, string role)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Role = role;
        }

        public void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the Date of birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            //Role = "Employee";
            Console.WriteLine("Please enter your Role : ");
            Role = Console.ReadLine();
            Console.WriteLine("Please enter your Employment type : ");
            Type = Console.ReadLine();
            Console.WriteLine("Please enter your salary : ");
            Salary = Convert.ToDouble(Console.ReadLine());
        }


        public override string ToString()
        {
            return "Employee Type : " + Type
                + "\nEmployee Id : " + Id
                + "\nEmployee Name " + Name
                + "\nDate of birth : " + DateOfBirth
                + "\nEmployee Age : " + Age
                + "\nEmployee Role " + Role;
        }

        //is called only when the obj is of same type. i.e employee and employee can be checked. not employee and depart.
        public override bool Equals(object? obj)
        {
            Employee e1, e2;
            e1 = this;
            //e2 = (Employee)obj;//Casting
            e2 = obj as Employee;//Casting in a more symanctic way
            return e1.Id.Equals(e2.Id);
        }


        //operator overloading
        //if == operator is overloaded then != operator also need to be overloaded.
        public static bool operator ==(Employee a, Employee b)
        {
            return a.Id == b.Id;

        }
        public static bool operator !=(Employee a, Employee b)
        {
            return a.Id != b.Id;
        }

    }
}
