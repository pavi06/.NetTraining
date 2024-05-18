namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string? Role { get; set; }

        public EmployeeDTO(int id, string name, DateTime dateOfBirth, string phone, string image, string? role)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Image = image;
            Role = role;
        }
    }
}
