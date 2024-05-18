using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerAPI.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string? Role { get; set; }

        public ICollection<Request> RequestsRaised { get; set; }//No effect on the table - navigation
        public ICollection<Request> RequestsClosed { get; set; }//No effect on the table - navigation

        public Employee(string name, DateTime dateOfBirth, string phone, string image, string? role)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Image = image;
            Role = role;
        }
    }
}
