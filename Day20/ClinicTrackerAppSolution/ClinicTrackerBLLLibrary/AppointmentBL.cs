using ClinicTrackerBLLLibrary.CustomExceptions;
using ClinicTrackerDALLibrary;
using ClinicTrackerDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLLibrary
{
    public class AppointmentBL : IAppointmentService
    {
        readonly IRepository<int, Appointment> _appointmentRepository;
        readonly IRepository<int, Patient> _patientRepository;
        readonly IRepository<int, Doctor> _doctorRepository;
        public AppointmentBL(IRepository<int, Appointment> appointmentRepository, IRepository<int, Patient> patientRepository, IRepository<int, Doctor> doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }
        public int AddAppointment(Appointment appointment)
        {
            var appointmentAdded = _appointmentRepository.Add(appointment);
            if (appointmentAdded != null)
            {
                var patient = _patientRepository.Get(appointment.Patient.Id);
                patient.Appointments.Add(appointment);
                _patientRepository.Update(patient);
                var doctor = _doctorRepository.Get(appointment.Doctor.Id);
                doctor.Appointments.Add(appointment);
                _doctorRepository.Update(doctor);
                return appointmentAdded.Id;
            }
            throw new ObjectAlreadyExistsException("Appointment already Exists!");
        }

        public Appointment DeleteAppointmentById(int id)
        {
            var appointment = _appointmentRepository.Delete(id);
            if (appointment != null)
            {
                var patient = _patientRepository.Get(appointment.Patient.Id);
                patient.Appointments.Remove(appointment);
                _patientRepository.Update(patient);
                var doctor = _doctorRepository.Get(appointment.Doctor.Id);
                doctor.Appointments.Remove(appointment);
                _doctorRepository.Update(doctor);
                return appointment;
            }
            throw new ObjectNotAvailableException($"Appointment with id {id} is not available!");
        }

        public List<Appointment> GetAllAppointments()
        {
            var appointmentList = _appointmentRepository.GetAll();
            if (appointmentList != null)
            {
                return appointmentList;
            }
            throw new NoAppointmentsAvailableException();
        }

        public List<Appointment> GetAllAppointmentsByDoctorId(int doctorId)
        {
            var appointments = GetAllAppointments();
            List<Appointment> appointmentsOfDoctor = new List<Appointment>();
            foreach (var appointment in appointments)
            {
                if (appointment.Doctor.Id == doctorId)
                {
                    appointmentsOfDoctor.Add(appointment);
                }
            }
            if (appointmentsOfDoctor.Count > 0)
            {
                return appointmentsOfDoctor;
            }
            throw new NoAppointmentsAvailableForObjectException($"Doctor with id {doctorId}");
        }

        public List<Appointment> GetAllAppointmentsByDoctorIdAndStatus(int doctorId, string status)
        {
            var appointments = GetAllAppointments();
            List<Appointment> appointmentsOfDoctor = new List<Appointment>();
            foreach (var appointment in appointments)
            {
                if (appointment.Doctor.Id == doctorId && appointment.AppointmentStatus == status)
                {
                    appointmentsOfDoctor.Add(appointment);
                }
            }
            if (appointmentsOfDoctor.Count > 0)
            {
                return appointmentsOfDoctor;
            }
            throw new NoAppointmentsAvailableForObjectException($"Doctor with id {doctorId} and appointment status {status}");
        }

        public List<Appointment> GetAllAppointmentsByPatientId(int patientId)
        {
            var appointments = GetAllAppointments();
            List<Appointment> appointmentsOfPatient = new List<Appointment>();
            foreach (var appointment in appointments)
            {
                if (appointment.Patient.Id == patientId)
                {
                    appointmentsOfPatient.Add(appointment);
                }
            }
            if (appointmentsOfPatient.Count > 0)
            {
                return appointmentsOfPatient;
            }
            throw new NoAppointmentsAvailableForObjectException($"Patient with id {patientId}");
        }

        public List<Appointment> GetAllAppointmentsByPatientIdAndStatus(int patientId, string status)
        {
            var appointments = GetAllAppointments();
            List<Appointment> appointmentsOfPatient = new List<Appointment>();
            foreach (var appointment in appointments)
            {
                if (appointment.Patient.Id == patientId && appointment.AppointmentStatus == status)
                {
                    appointmentsOfPatient.Add(appointment);
                }
            }
            if (appointmentsOfPatient.Count > 0)
            {
                return appointmentsOfPatient;
            }
            throw new NoAppointmentsAvailableForObjectException($"Patient with id {patientId} and appointment status {status}");
        }

        public List<Appointment> GetAllAppointmentsByStatus(string status)
        {
            var appointmentList = GetAllAppointments();
            List<Appointment> appointments = new List<Appointment>();
            foreach (var appointment in appointmentList)
            {
                if (appointment.AppointmentStatus == status)
                {
                    appointments.Add(appointment);
                }
            }
            if (appointments.Count > 0)
            {
                return appointments;
            }
            throw new NoAppointmentsAvailableException();
        }

        public Appointment GetAppointmentById(int id)
        {
            var appointment = _appointmentRepository.Get(id);
            if (appointment != null)
            {
                return appointment;
            }
            throw new ObjectNotAvailableException($"Appointment with id {id} is not available!");
        }

        public Doctor GetDoctorByAppointmentId(int id)
        {
            var appointment = GetAppointmentById(id);
            if (appointment.Doctor != null)
            {
                return appointment.Doctor;
            }
            throw new ObjectIsNotAssociatedWithAppointmentException("Doctor", appointment.Doctor.Id, id);
        }

        public Patient GetPatientByAppointmentId(int id)
        {
            var appointment = GetAppointmentById(id);
            if (appointment.Patient != null)
            {
                return appointment.Patient;
            }
            throw new ObjectIsNotAssociatedWithAppointmentException("Patient", appointment.Patient.Id, id);
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var appointmentUpdated = _appointmentRepository.Update(appointment);
            if (appointmentUpdated != null)
            {
                var patientAppointments = _patientRepository.Get(appointment.Patient.Id).Appointments;
                int pIndex = patientAppointments.ToList().FindIndex(a => a.Id == appointment.Id);
                if (pIndex != -1)
                {
                    patientAppointments.ToList()[pIndex] = appointmentUpdated;
                }
                var doctorAppointments = _doctorRepository.Get(appointment.Doctor.Id).Appointments;
                int dIndex = doctorAppointments.ToList().IndexOf(appointment);
                if (dIndex != -1)
                {
                    doctorAppointments.ToList()[dIndex] = appointmentUpdated;
                }
                return appointmentUpdated;
            }
            throw new ObjectNotAvailableException($"Appointment with id {appointment.Id} is not available!");
        }

        public bool UpdateAppointmentDateAndTimeById(int id, DateTime dateTime)
        {
            var appointment = GetAppointmentById(id);
            appointment.AppointmentDateTime = dateTime;
            if (UpdateAppointment(appointment) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAppointmentDescription(int id, string description)
        {
            var appointment = GetAppointmentById(id);
            appointment.AppointmentDescription = description;
            if (UpdateAppointment(appointment) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAppointmentStatusById(int id, string status)
        {
            var appointment = GetAppointmentById(id);
            appointment.AppointmentStatus = status;
            if (UpdateAppointment(appointment) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
