namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class UserActivationDTO
    {
        public int EmployeeId { get; set; }
        public string Status { get; set; }

        public UserActivationDTO(int employeeId, string status)
        {
            EmployeeId = employeeId;
            Status = status;
        }
    }
}
