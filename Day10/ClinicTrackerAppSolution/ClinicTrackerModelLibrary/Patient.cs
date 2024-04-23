using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerModelLibrary
{
    public class Patient
    {
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string BloodGroup { get; set; }
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="id">id of int type</param>
        /// <param name="name">name of string type</param>
        /// <param name="age">age of int type</param>
        /// <param name="gender">gender of string type</param>
        /// <param name="address">address of string type</param>
        /// <param name="phonenumber">phonenumber of string type</param>
        /// <param name="bloodGroup">bloodgroup of string type</param>
        /// 

        public Patient() { }

        public Patient(int id) { 
            Id = id;
        }
        public Patient(string name, int age, string gender, string address,string phonenumber,string bloodGroup, List<Appointment> appointments) 
        {
            Name = name;
            Age = age;
            Gender = gender;
            Address = address;
            PhoneNumber = phonenumber;
            BloodGroup = bloodGroup;
            Appointments = appointments;
        }
        /// <summary>
        /// Overridden method for displaying Patient details.
        /// </summary>
        /// <returns>concatenated string which holds all the attribute value</returns>
        public override string ToString()
        {
            return "Patient Id : " + Id
                + "\nPatient Name " + Name
                + "\nPatient Age : " + Age
                +"\nGender : "+Gender
                +"\nAddress : "+Address
                +"\nPhone Number : "+PhoneNumber
                + "\nPatient BloodGroup " + BloodGroup;
        }

        public override bool Equals(object? obj)
        {
            Patient e1, e2;
            e1 = this;
            e2 = obj as Patient;
            return e1.Id.Equals(e2.Id);
        }

    }
}
