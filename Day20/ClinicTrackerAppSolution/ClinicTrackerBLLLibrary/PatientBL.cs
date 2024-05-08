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
    public class PatientBL : IPatientService
    {
        readonly IRepository<int, Patient> _patientRepository;
        public PatientBL(IRepository<int, Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public int AddPatient(Patient patient)
        {
            var patientAdded = _patientRepository.Add(patient);
            if (patientAdded != null)
            {
                return patientAdded.Id;
            }
            throw new ObjectAlreadyExistsException("Patient Already Exists!");
        }

        public Patient GetPatientById(int id)
        {
            var patient = _patientRepository.Get(id);
            if (patient != null)
            {
                return patient;
            }
            throw new ObjectNotAvailableException($"Patient with the id {id} is not available!");
        }

        public Patient DeletePatientById(int id)
        {
            var patient = _patientRepository.Delete(id);
            if (patient != null)
            {
                return patient;
            }
            throw new ObjectNotAvailableException($"Patient with the id {id} is not available!"); ;
        }

        public Patient UpdatePatientByObject(Patient patient)
        {
            var updatedPatient = _patientRepository.Update(patient);
            if (updatedPatient != null)
            {
                return updatedPatient;
            }
            throw new ObjectNotAvailableException($"Patient with the id {patient.Id} is not available!"); ;
        }

        public bool UpdatePatientAddressById(int id, string address)
        {
            var patient = GetPatientById(id);
            patient.ContactAddress = address;
            if (UpdatePatientByObject(patient) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePatientAgeById(int id, int age)
        {
            var patient = GetPatientById(id);
            patient.Age = age;
            if (UpdatePatientByObject(patient) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePatientNameById(int id, string name)
        {
            var patient = GetPatientById(id);
            patient.PatientName = name;
            if (UpdatePatientByObject(patient) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePatientPhoneNumberById(int id, string phoneNumber)
        {
            var patient = GetPatientById(id);
            patient.PhoneNumber = phoneNumber;
            if (UpdatePatientByObject(patient) != null)
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
