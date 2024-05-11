using System;
using System.Collections.Generic;

namespace ClinicTrackerDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? PatientName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? ContactAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BloodGroup { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nName : {PatientName}\nAge : {Age}\nGender : {Gender}\nContactAddress : {ContactAddress}\nPhoneNumber : {PhoneNumber}\nBloodGroup : {BloodGroup}";
        }
    }
}
