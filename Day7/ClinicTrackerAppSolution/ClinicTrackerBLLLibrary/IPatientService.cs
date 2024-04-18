using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLLibrary
{
    public interface IPatientService
    {
        /// <summary>
        /// Method to add a new patient.
        /// </summary>
        /// <param name="patient">Object of patient type is passed</param>
        /// <returns>returns the id of the patient object</returns>
        int AddPatient(Patient patient);

        /// <summary>
        /// Method to retrieve the patient object by passing the id of the patient 
        /// </summary>
        /// <param name="id">id of int datatype</param>
        /// <returns>returns patient object</returns>
        Patient GetPatientById(int id);

        /// <summary>
        /// Method to retrieve all the appointments that are related to that patient object.
        /// </summary>
        /// <param name="id">id of int type</param>
        /// <returns>returns list of appointment for the patient</returns>
        List<Appointment> GetAllAppointmentsByPatientId(int id);
        
        List<Appointment> GetAllAppointmentsByPatientIdAndStatus(int id,string status);

        /// <summary>
        /// Method to delete the patient object by passing its id
        /// </summary>
        /// <param name="id">id of int type</param>
        /// <returns>returns the deleted patient object</returns>
        Patient DeletePatientById(int id);

        /// <summary>
        /// Method to update the patient object
        /// </summary>
        /// <param name="patient">object of patient type</param>
        /// <returns>returns the updated patient object</returns>
        Patient UpdatePatientByObject(Patient patient);
        /// <summary>
        /// Method to update the name of the patient object
        /// </summary>
        /// <param name="id">id of int type</param>
        /// <param name="name">name of string type</param>
        /// <returns>returns true if the value is updated else return false</returns>
        bool UpdatePatientNameById(int id, string name);

        //method to update age by passing id and age
        bool UpdatePatientAgeById(int id, int age);
        //method to update address by passing id and address
        bool UpdatePatientAddressById(int id, string address);
        //method to update phonenumber by passing id and phonenumber
        bool UpdatePatientPhoneNumberById(int id, string phoneNumber);

    }
}
