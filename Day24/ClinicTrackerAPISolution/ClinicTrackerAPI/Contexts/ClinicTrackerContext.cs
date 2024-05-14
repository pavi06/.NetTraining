using ClinicTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicTrackerAPI.Contexts
{
    public class ClinicTrackerContext : DbContext
    {
        public ClinicTrackerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101, Name = "Sai", Age = 28, PhoneNumber = "9876543321", Experience = 3 , Specialization = "Cardialogists", Qualification = "MBBS, MD"},
                new Doctor() { Id = 102, Name = "Shiva", Age = 35, PhoneNumber = "9988776655", Experience = 8 , Specialization = "Neurologists" , Qualification = "MBBS, MD"}
                );
        }
    }
}
