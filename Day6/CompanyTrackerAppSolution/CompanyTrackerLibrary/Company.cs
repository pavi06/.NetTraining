namespace CompanyTrackerLibrary
{
    public class Company
    {
        public int EmpId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public double ServiceCompleted { get; set; }
        public double BasicSalary { get; set; }
        public string companyType { get; set; }

        public Company()
        {
            EmpId = 0;
            Name = string.Empty;
            Department = string.Empty;
            Designation = string.Empty;
            ServiceCompleted = 0;
            BasicSalary = 0.0;
        }
        public Company(int id, string name, string department , string designation , double serviceYears, double basicSalary)
        {
            //Console.WriteLine("Employee class prameterized constructor");
            EmpId = id;
            Name = name;
            Department = department;
            Designation = designation;
            ServiceCompleted = serviceYears;
            BasicSalary = basicSalary;
        }

        public virtual void DisplayDetails() {
            Console.WriteLine("-----------Employee Details------------");
            Console.WriteLine("Employee Id : "+EmpId);
            Console.WriteLine("Employee Name : "+Name);
            Console.WriteLine("Employee Department : " + Department);
            Console.WriteLine("Employee Designation : " + Designation);
            Console.WriteLine("Employee Service Years : "+ ServiceCompleted);
        }
    }
}
