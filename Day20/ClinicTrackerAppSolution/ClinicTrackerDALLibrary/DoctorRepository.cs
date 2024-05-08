using ClinicTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        dbClinicContext clinicContext;
        public DoctorRepository()
        {
            clinicContext = new dbClinicContext();
        }

        public Doctor Add(Doctor item)
        {
            if (clinicContext.Doctors.Contains(item))
            {
                return null;
            }
            clinicContext.Doctors.Add(item);
            clinicContext.SaveChanges();
            return item;
        }

        public Doctor Delete(int key)
        {
            var doctor = clinicContext.Doctors.FirstOrDefault(d => d.Id == key);
            if (doctor != null)
            {
                clinicContext.Doctors.Remove(doctor);
                clinicContext.SaveChanges();
                return doctor;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            return clinicContext.Doctors.FirstOrDefault(d => d.Id == key);
        }

        public List<Doctor> GetAll()
        {
            var doctorList = clinicContext.Doctors.ToList();
            if (doctorList.Count == 0)
                return null;
            return doctorList;
        }

        public Doctor Update(Doctor item)
        {
            var doctor = clinicContext.Doctors.FirstOrDefault(d => d.Id == item.Id);
            if (doctor != null)
            {
                doctor = item;
                clinicContext.Doctors.Update(doctor);
                clinicContext.SaveChanges();
                return doctor;
            }
            return null;
        }
    }
}
