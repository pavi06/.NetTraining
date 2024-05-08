using ClinicTrackerDALLibrary.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClinicTrackerDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        dbClinicContext clinicContext;
        public PatientRepository()
        {
            clinicContext = new dbClinicContext();
        }

        public Patient Add(Patient item)
        {
            if (clinicContext.Patients.Contains(item))
            {
                return null;
            }
            clinicContext.Patients.Add(item);
            clinicContext.SaveChanges();
            return item;
        }

        public Patient Delete(int key)
        {            
            var patient = clinicContext.Patients.FirstOrDefault(p => p.Id == key);
            if(patient != null)
            {
                clinicContext.Patients.Remove(patient);
                clinicContext.SaveChanges() ;
                return patient;
            }
            return null;
        }

        public Patient Get(int key)
        {
            return clinicContext.Patients.FirstOrDefault(p => p.Id == key);
        }

        public List<Patient> GetAll()
        {
            var patientList = clinicContext.Patients.ToList();
            if (patientList.Count == 0)
                return null;
            return patientList;
        }

        public Patient Update(Patient item)
        {
            var patient = clinicContext.Patients.FirstOrDefault(p => p.Id == item.Id);
            if (patient != null)
            {
                patient = item;
                clinicContext.Patients.Update(patient);
                clinicContext.SaveChanges();
                return patient;
            }
            return null;
        }
    }
}
