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

        public override string ToString()
        {
            return $"Id: {Id}\nAppointmentDateTime : {AppointmentDateTime}\nAppointmentDescription : {AppointmentDescription}\nAppointmentStatus: {AppointmentStatus}\nPatientId : {PatientId}\nDoctorId : {DoctorId}";
        }
    }
}
