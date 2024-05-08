using ClinicTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLLibrary
{
    public interface IDoctorService
    {
        /// <summary>
        /// This method will add the doctor to the system
        /// </summary>
        /// <param name="doctor"> object of doctor type is passed as a parameter</param>
        /// <returns>returns the id of the doctor creacted</returns>
        int AddDoctor(Doctor doctor);

        /// <summary>
        /// This method will retrieve the doctor object by passing the id  to it.
        /// </summary>
        /// <param name="id">id of int type is passed as an input</param>
        /// <returns>returns the doctor object</returns>
        Doctor GetDoctorById(int id);


        /// <summary>
        /// method to delete the doctor object
        /// </summary>
        /// <param name="id">id of int datatype</param>
        /// <returns>returns the deleted object</returns>
        Doctor DeleteDoctorById(int id);

        /// <summary>
        /// method to update the doctor object
        /// </summary>
        /// <param name="doctor">object of doctor type</param>
        /// <returns>returns the updated doctor object</returns>
        Doctor UpdateDoctorByObject(Doctor doctor);

        /// <summary>
        /// Method to update the doctor name by passing the id and new name
        /// </summary>
        /// <param name="id">id of int datatype</param>
        /// <param name="name">name of string datatype</param>
        /// <returns>returns true if updated successfully else return false</returns>
        bool UpdateDoctorNameById(int id, string name);
        //method to update the age of the doctor by passing the id and the new age 
        bool UpdateDoctorAgeById(int id, int age);
        //method to update the phonenumber of the doctor by passing the id and the new phonenumber 
        bool UpdateDoctorPhoneNumberById(int id, string phoneNumber);
        //method to update the experience of the doctor by passing the id and the new experience
        bool UpdateDoctorExperienceById(int id, int experience);
        //method to update the specialization of the doctor by passing the id and the new specialization 
        bool UpdateDoctorSpecializationById(int id, string specialization);
        //method to update the qualification of the doctor by passing the id and the new qualification 
        bool UpdateDoctorQualificationById(int id, string qualification);

    }
}
