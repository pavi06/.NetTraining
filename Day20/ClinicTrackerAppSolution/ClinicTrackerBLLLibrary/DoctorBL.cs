using ClinicTrackerBLLLibrary.CustomExceptions;
using ClinicTrackerDALLibrary;
using ClinicTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLLibrary
{
    public class DoctorBL : IDoctorService
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        public DoctorBL(IRepository<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public int AddDoctor(Doctor doctor)
        {
            var doctorAdded = _doctorRepository.Add(doctor);
            if (doctorAdded != null)
            {
                return doctorAdded.Id;
            }
            throw new ObjectAlreadyExistsException("Doctor Already Exists!");
        }

        public Doctor GetDoctorById(int id)
        {
            var doctor = _doctorRepository.Get(id);
            if (doctor != null)
            {
                return doctor;
            }
            throw new ObjectNotAvailableException($"Doctor with the id {id} is not available!"); ;
        }

        public Doctor DeleteDoctorById(int id)
        {
            var doctor = _doctorRepository.Delete(id);
            if (doctor != null)
            {
                return doctor;
            }
            throw new ObjectNotAvailableException($"Doctor with the id {id} is not available!");
        }

        public bool UpdateDoctorAgeById(int id, int age)
        {
            var doctor = GetDoctorById(id);
            doctor.Age = age;
            if (UpdateDoctorByObject(doctor) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Doctor UpdateDoctorByObject(Doctor doctor)
        {
            var updatedDoctor = _doctorRepository.Update(doctor);
            if (updatedDoctor != null)
            {
                return updatedDoctor;
            }
            throw new ObjectNotAvailableException($"Doctor with the id {doctor.Id} is not available!"); ;
        }

        public bool UpdateDoctorExperienceById(int id, int experience)
        {
            var doctor = GetDoctorById(id);
            doctor.Experience = experience;
            if (UpdateDoctorByObject(doctor) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDoctorNameById(int id, string name)
        {
            var doctor = GetDoctorById(id);
            doctor.DocName = name;
            if (UpdateDoctorByObject(doctor) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDoctorPhoneNumberById(int id, string phoneNumber)
        {
            var doctor = GetDoctorById(id);
            doctor.PhoneNumber = phoneNumber;
            if (UpdateDoctorByObject(doctor) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDoctorQualificationById(int id, string qualification)
        {
            var doctor = GetDoctorById(id);
            doctor.Qualification = qualification;
            if (UpdateDoctorByObject(doctor) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDoctorSpecializationById(int id, string specialization)
        {
            var doctor = GetDoctorById(id);
            doctor.Specialization = specialization;
            if (UpdateDoctorByObject(doctor) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
