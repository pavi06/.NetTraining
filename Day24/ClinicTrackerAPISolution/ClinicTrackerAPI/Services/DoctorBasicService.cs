using ClinicTrackerAPI.Exceptions;
using ClinicTrackerAPI.Interfaces;
using ClinicTrackerAPI.Models;

namespace ClinicTrackerAPI.Services
{
    public class DoctorBasicService : IDoctorService
    {
        protected readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorBasicService(IRepository<int, Doctor> doctorRepository) { 
            _doctorRepository = doctorRepository;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _doctorRepository.Get();
            if(doctors.ToList().Count>0)
                return doctors.ToList();
            throw new NoDoctorsAvailableException("");
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string speciality)
        {
            var doctors = _doctorRepository.Get().Result.Where(d=>d.Specialization == speciality).ToList();
            if (doctors.Count>0)
                return doctors;
            throw new NoDoctorsAvailableException($"with {speciality} speciality");
        }

        public async Task<Doctor> UpdateDoctorExperience(int docId, int experience)
        {
            var doctor = await _doctorRepository.Get(docId);
            if (doctor == null)
                throw new NoSuchDoctorAvailableException();
            doctor.Experience = experience;
            var updatedDoctor = await _doctorRepository.Update(doctor);
            return updatedDoctor;            
        }
    }
}
