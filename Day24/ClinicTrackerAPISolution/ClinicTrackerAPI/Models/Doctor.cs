namespace ClinicTrackerAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public double Experience { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }

    }
}
