using ClinicTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        dbClinicContext clinicContext;
        public AppointmentRepository()
        {
            clinicContext = new dbClinicContext();
        }


        public Appointment Add(Appointment item)
        {
            if (clinicContext.Appointments.Contains(item))
            {
                return null;
            }
            clinicContext.Appointments.Add(item);
            clinicContext.SaveChanges();
            return item;
        }

        public Appointment Delete(int key)
        {
            var appointment = clinicContext.Appointments.FirstOrDefault(a => a.Id == key);
            if (appointment != null)
            {
                clinicContext.Appointments.Remove(appointment);
                clinicContext.SaveChanges();
                return appointment;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            var appointment = clinicContext.Appointments.FirstOrDefault(a => a.Id == key);
            if (appointment != null)
            {
                return appointment;
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            var appointmentList = clinicContext.Appointments.ToList();
            if (appointmentList.Count == 0)
                return null;
            return appointmentList;
        }

        public Appointment Update(Appointment item)
        {
            var appointment = clinicContext.Appointments.FirstOrDefault(a => a.Id == item.Id);
            if (appointment != null)
            {
                appointment = item;
                clinicContext.Appointments.Update(appointment);
                clinicContext.SaveChanges();
                return appointment;
            }
            return null;
        }
    }
}
