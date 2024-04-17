﻿using System.Data;

namespace ClinicTrackerModelLibrary
{
    public class Doctor
    {
        readonly List<Appointment> _appointments;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public double Experience { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }

        public Doctor()
        {
            Id = 0;
            Age = 0;
            Name = string.Empty;
            Experience = 0;
            Qualification = string.Empty;
            Specialization = string.Empty;
            _appointments = new List<Appointment>();

        }
        public Doctor(int id)
        {
            Id = id;
        }


        public Doctor(int id, string name, int age, int experience, string qualification, string speciality) : this(id)
        {
            Name = name;
            Age = age;
            Experience = experience;
            Qualification = qualification;
            Specialization = speciality;
        }

        public override string ToString()
        {
            return "Doctor Id : " + Id
                + "\nDoctor Name " + Name
                + "\nDoctor Age : " + Age
                + "\nDoctor Experience " + Experience
                + "\nDoctor Specialization : " + Specialization;
        }

        /// <summary>
        /// Overrides the Equals method to check if two objects are same with respect to ID.
        /// </summary>
        /// <param name="obj">object to check</param>
        /// <returns> boolean value (true - if same , false - not same)</returns>
        public override bool Equals(object? obj)
        {
            Doctor e1, e2;
            e1 = this;
            e2 = obj as Doctor;
            return e1.Id.Equals(e2.Id);
        }

    }
}
