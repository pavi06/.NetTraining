using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLLibrary
{
    public interface IAppointmentService
    {
        /// <summary>
        /// Method to add apointment
        /// </summary>
        /// <param name="appointment">object of appointment type</param>
        /// <returns>returns the id of the apoointment created</returns>
        int AddAppointment(Appointment appointment);
        
        /// <summary>
        /// Method to get the appointment by id
        /// </summary>
        /// <param name="id">id of int datatype</param>
        /// <returns>returns appointment object</returns>
        Appointment GetAppointmentById(int id);
        //returns the list of apoointments
        List<Appointment> GetAllAppointments();
        List<Appointment> GetAllAppointmentsByStatus(string status);

        List<Appointment> GetAllAppointmentsByPatientId(int patientId);

        List<Appointment> GetAllAppointmentsByPatientIdAndStatus(int patientId,  string status);

        List<Appointment> GetAllAppointmentsByDoctorId(int doctorId);

        List<Appointment> GetAllAppointmentsByDoctorIdAndStatus(int doctorId, string status);
        //delete apoointment by the id passed to it and return the deleted object
        Appointment DeleteAppointmentById(int id);
        //update appointment and return the object 
        Appointment UpdateAppointment(Appointment appointment);
        bool UpdateAppointmentDateAndTimeById(int id, DateTime dateTime);

        /// <summary>
        /// method to get doctor object by passing the appointment id that is associated with the patient object
        /// </summary>
        /// <param name="id">id of int datatype</param>
        /// <returns>returns the doctor object</returns>
        Doctor GetDoctorByAppointmentId(int id);

        /// <summary>
        /// method to get patient object by passing the appointment id that is associated with the patient object
        /// </summary>
        /// <param name="id">id of int datatype</param>
        /// <returns>returns the patient object</returns>
        Patient GetPatientByAppointmentId(int id);
        /// <summary>
        /// Method to update the status of the appointment object
        /// </summary>
        /// <param name="id">id of int type</param>
        /// <param name="status">status of string type</param>
        /// <returns>returns true if the update is done successful, else returns false</returns>
        bool UpdateAppointmentStatusById(int id,string status);

        //method to update the description if needed by passing the id of the appointment object and the new description .
        bool UpdateAppointmentDescription(int id, string description);

    }
}
