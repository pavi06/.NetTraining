using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems2.Models
{
    class Doctor
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Exp { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        public Doctor()
        {
            Id = 0;
            Name = string.Empty;
            Age= 0;
            Exp = 0;
            Qualification = string.Empty; 
            Speciality = string.Empty;
       
        }

        /// <summary>
        /// Constructor with id attribute
        /// </summary>
        /// <param name="id">id of the doctor should be in int</param>
        public Doctor(int id) {
            Id = id;
        }


        public Doctor(int id, string name, int age, int exp, string qualification, string speciality) : this(id)
        {
            Name = name;
            Age = age;
            Exp = exp;
            Qualification = qualification;
            Speciality = speciality;
        }

        public void PrintDoctorDetails(bool val)
        {
            if(val==true)
            {
                Console.WriteLine($"Doctor Id\t: {Id}");
            }
            Console.WriteLine($"Doctor name\t: {Name}");
            Console.WriteLine($"Doctor Age\t: {Age}");
            Console.WriteLine($"Doctor Exp\t: {Exp}");
            Console.WriteLine($"Doctor Qualification\t: {Qualification}");
            Console.WriteLine($"Doctor Speciality\t: {Speciality}");
        }
    }
}
