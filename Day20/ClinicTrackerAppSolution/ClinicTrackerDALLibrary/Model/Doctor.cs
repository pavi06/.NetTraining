using System;
using System.Collections.Generic;

namespace ClinicTrackerDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? DocName { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public double? Experience { get; set; }
        public string? Specialization { get; set; }
        public string? Qualification { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public override bool Equals(object? obj)
        {
            Doctor obj1 = obj as Doctor;
            return this.DocName == obj1.DocName && this.Age == obj1.Age &&
                this.PhoneNumber == obj1.PhoneNumber && this.Experience == obj1.Experience &&
                this.Specialization == obj1.Specialization && this.Qualification == obj1.Qualification;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {DocName}\nAge : {Age}\nPhoneNumber : {PhoneNumber}\nExperience : {Experience}\nSpecialization : {Specialization}\nQualification : {Qualification}";
        }
    }
}
