using ClinicTrackerBLLLibrary;
using ClinicTrackerBLLLibrary.CustomExceptions;
using ClinicTrackerDALLibrary;
using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLTests
{
    public class AppointmentBLTest
    {
        IRepository<int, Appointment> appointmentRepository;
        IAppointmentService appointmentService;

        [SetUp]
        public void Setup()
        {
            appointmentRepository = new AppointmentRepository();
            //Patient patient = new Patient() { Name = "Pavithra", Age = 25, Address = "No.3 sai street, Korattur, Chennai", BloodGroup = "AB+ve", Gender = "Female", PhoneNumber = "9897654343", Appointments = { new Appointment(1, new DateTime(2024, 08, 12), "General checkup", "Not Completed") } };
            //Doctor doctor = new Doctor() { Name = "Viji", Age = 30, PhoneNumber = "8786543453", Experience = 10, Qualification = "MBBS", Specialization = "Neurologist", Appointments = { new Appointment(2, new DateTime(2024, 05, 03), "General checkup", "Not Completed") } };

            Appointment appointment = new Appointment(1, new DateTime(2024, 08, 12), "General checkup", "Not Completed");
            appointmentRepository.Add(appointment);
            appointmentService = new AppointmentBL(appointmentRepository);
        }

        [Test]
        public void AddAppointmentPassTest()
        {
            //Arrange

            Appointment appointment = new Appointment( 2, new DateTime(2024, 10, 24), "General Description", "Completed" );
            //action
            var addedAppointment = appointmentService.AddAppointment(appointment);
            //Assert
            Assert.IsNotNull(addedAppointment);
        }

        [Test]
        public void AppointmentAlreadyExistsExceptionTest()
        {
            Appointment appointment = new Appointment(1, new DateTime(2024, 08, 12), "General checkup", "Not Completed");
            //Action
            var exception = Assert.Throws<ObjectAlreadyExistsException>(() => appointmentService.AddAppointment(appointment));
            //Assert
            Assert.AreEqual("Appointment already Exists!", exception.Message);
        }

        [Test]
        public void DeleteAppointmentPassTest()
        {
            //action
            var appointment = appointmentService.DeleteAppointmentById(1);
            //Assert
            Assert.IsNotNull(appointment);
        }

        [Test]
        public void DeleteAppointmentNotAvailableExceptionTest()
        {
            //Action
            int id = 4;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => appointmentService.DeleteAppointmentById(id));
            //Assert
            Assert.AreEqual($"Appointment with id {id} is not available!", exception.Message);
        }

        [Test]
        public void GetAllAppointmentsPassTest()
        {
            var appointments = appointmentService.GetAllAppointments();
            Assert.IsNotEmpty(appointments);
        }

        [Test]
        public void GetAllAppointmentsExceptionTest()
        {
            var exception = Assert.Throws<NoAppointmentsAvailableException>(() => appointmentService.GetAllAppointments());
            Assert.AreEqual($"No appointments available!", exception.Message);
        }

        [Test]
        public void GetAllAppointmentByStatusPassTest()
        {
            var appointments = appointmentService.GetAllAppointmentsByStatus("Not Completed");
            Assert.IsNotEmpty(appointments);
        }

        [Test]
        public void GetAllAppointmentByStatusExceptionTest()
        { 
            string status = "Initiated";
            var exception = Assert.Throws<NoAppointmentsAvailableException>(() => appointmentService.GetAllAppointmentsByStatus(status));
            Assert.AreEqual("No appointments available!", exception.Message);
        }

        [Test]
        public void UpdateAppointmentPassTest()
        {
            var appointment = appointmentService.GetAppointmentById(1) ;
            appointment.AppointmentStatus = "Completed";
            var updatedAppointment = appointmentService.UpdateAppointment(appointment);
            Assert.IsNotNull(updatedAppointment);

        }
        [Test]
        public void UpdateAppointmentExceptionTest()
        {
            Appointment appointment = new Appointment(3, new DateTime(2024, 10, 24), "General Description", "Completed");
            var exception = Assert.Throws<ObjectNotAvailableException>(() => appointmentService.UpdateAppointment(appointment));
            //Assert
            Assert.AreEqual($"Appointment with id {appointment.Id} is not available!", exception.Message);
        }

        [Test]
        public void UpdateAppointmentDateTimePassTest()
        {
            var result = appointmentService.UpdateAppointmentDateAndTimeById(1, new DateTime(2024,05,17));
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdateAppointmentDateTimeExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => appointmentService.UpdateAppointmentDateAndTimeById(id, new DateTime(2024,05,16)));
            Assert.AreEqual($"Appointment with id {id} is not available!", exception.Message);
        }

        [Test]
        public void UpdateAppointmentDescriptionPassTest()
        {
            var result = appointmentService.UpdateAppointmentDescription(1, "Regular checkup");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdateAppointmentDescriptionExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => appointmentService.UpdateAppointmentDescription(id, "Regular Checkup"));
            Assert.AreEqual($"Appointment with id {id} is not available!", exception.Message);
        }

        [Test]
        public void UpdateAppointmentStatusPassTest()
        {
            var result = appointmentService.UpdateAppointmentStatusById(1, "Completed");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdateAppointmentStatusExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => appointmentService.UpdateAppointmentStatusById(id, "Completed"));
            Assert.AreEqual($"Appointment with id {id} is not available!", exception.Message);
        }


        [Test]
        public void GetPatientPassTest() {
            var patient = appointmentService.GetPatientByAppointmentId(1);
            Assert.IsNotNull(patient);
        }

        [Test]
        public void GetDoctorPassTest()
        {
            var doctor = appointmentService.GetDoctorByAppointmentId(1);
            Assert.IsNotNull(doctor);
        }
    }
}
