using ClinicTrackerAPI.Models;

namespace ClinicTrackerAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<Doctor> UpdateDoctorExperience(int docId, int experience);
        public Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string speciality);

    }
}
