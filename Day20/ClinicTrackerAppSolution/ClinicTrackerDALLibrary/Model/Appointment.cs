using System;
using System.Collections.Generic;

namespace ClinicTrackerDALLibrary.Model
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public string? AppointmentDescription { get; set; }
        public string? AppointmentStatus { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }

        //public override bool Equals(object? obj)
        //{
        //    Appointment obj1 = obj as Appointment;
        //    return this.AppointmentDateTime == obj1.AppointmentDateTime && this.AppointmentDescription == obj1.AppointmentDescription
        //        && this.AppointmentStatus == obj1.AppointmentStatus && this.PatientId == obj1.PatientId && this.DoctorId == obj1.DoctorId;
        //}

        public override string ToString()
        {
            return $"Id: {Id}\nAppointmentDateTime : {AppointmentDateTime}\nAppointmentDescription : {AppointmentDescription}\nAppointmentStatus: {AppointmentStatus}\nPatientId : {PatientId}\nDoctorId : {DoctorId}";
        }
    }
}
