using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerModelLibrary
{
    public class Appointment
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public int Id { get; set; }
        public DateTime AppointmentDateAndTime { get; set; }
        public string AppointmentDescription { get; set; }
        public string AppointmentStatus { get; set; }

        public Appointment(int id, Patient patient, Doctor doctor, DateTime appointmentDateAndTime, string appointmentDescription, string appointmentStatus)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            AppointmentDateAndTime = appointmentDateAndTime;
            AppointmentDescription = appointmentDescription;
            AppointmentStatus = appointmentStatus;
        }

        public override string ToString()
        {
            return $"Appointment Id : {Id}\nAppointment Date and Time : {AppointmentDateAndTime}\nPatient Name : {Patient.Name}" +
                $"Doctor Name : {Doctor.Name}\nAppointment Description : {AppointmentDescription}\nAppointment Status : {AppointmentStatus}";
        }
    }
}
