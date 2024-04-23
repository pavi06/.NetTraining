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
    public class DoctorBLTest
    {

        IRepository<int, Doctor> doctorRepository;
        IDoctorService doctorService;

        [SetUp]
        public void Setup()
        {
            doctorRepository = new DoctorRepository();
            Doctor doctor = new Doctor() { Name = "Viji", Age = 30, PhoneNumber = "8786543453", Experience = 10, Qualification = "MBBS", Specialization = "Neurologist", Appointments = { new Appointment(1, new DateTime(2024, 05, 03), "General checkup", "Not Completed") } };
            doctorRepository.Add(doctor);
            doctor = new Doctor() { Name = "Pavithra", Age = 30, PhoneNumber = "8786543453", Experience = 10, Qualification = "MBBS", Specialization = "Neurologist" };
            doctorRepository.Add(doctor);
            doctorService = new DoctorBL(doctorRepository);
        }

        [Test]
        public void AddDoctorPassTest()
        {
            //Arrange
            Doctor doctor = new Doctor() { Name = "Pavi", Age = 35, PhoneNumber = "878978553", Experience = 10, Qualification = "MBBS", Specialization = "Neurologist", Appointments = { new Appointment(2, new DateTime(2024, 05, 03), "General checkup", "Not Completed") } };
            //action
            var addedDoctor = doctorService.AddDoctor(doctor);
            //Assert
            Assert.IsNotNull(addedDoctor);
        }

       
        [Test]
        public void DoctorAlreadyExistsExceptionTest()
        {
            Doctor doctor = new Doctor() { Id = 1, Name = "Pavi", Age = 35, PhoneNumber = "878978553", Experience = 10, Qualification = "MBBS", Specialization = "Neurologist", Appointments = { new Appointment(1, new DateTime(2024, 05, 03), "General checkup", "Not Completed") } };
            //Action
            var exception = Assert.Throws<ObjectAlreadyExistsException>(() => doctorService.AddDoctor(doctor));
            //Assert
            Assert.AreEqual("Doctor Already Exists!", exception.Message);
        }

        [Test]
        public void GetDoctorPassTest()
        {
            //action
            var doctor = doctorService.GetDoctorById(1);
            //Assert
            Assert.IsNotNull(doctor);
        }

        [Test]
        public void DoctorNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => doctorService.GetDoctorById(id));
            //Assert
            Assert.AreEqual($"Doctor with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void DeleteDoctorPassTest()
        {
            //action
            var doctor = doctorService.DeleteDoctorById(1);
            //Assert
            Assert.IsNotNull(doctor);
        }

        [Test]
        public void DeleteDoctorNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => doctorService.DeleteDoctorById(id));
            //Assert
            Assert.AreEqual($"Doctor with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void GetAllAppointmentByDoctorPassTest() {
            var appointments = doctorService.GetAllAppointmentsByDoctorId(1);
            Assert.IsNotEmpty(appointments);
        }

        [Test]
        public void GetAllAppointmentByDoctorExceptionTest()
        {
            int id = 2;
            var exception = Assert.Throws<NoAppointmentsAvailableForObjectException>(() => doctorService.GetAllAppointmentsByDoctorId(id));
            Assert.AreEqual($"No appointments available for Doctor with id {id}!", exception.Message);
        }

        [Test]
        public void GetAllAppointmentByDoctorIdAndStatusPassTest()
        {
            var appointments = doctorService.GetAllAppointmentsByDoctorIdAndStatus(1,"Not Completed");
            Assert.IsNotEmpty(appointments);
        }

        [Test]
        public void GetAllAppointmentByDoctorIdAndStatusExceptionTest()
        {
            int id = 2;
            string status = "Completed";
            var exception = Assert.Throws<NoAppointmentsAvailableForObjectException>(() => doctorService.GetAllAppointmentsByDoctorIdAndStatus(id, status));
            Assert.AreEqual($"No appointments available for Doctor with id {id} and appointment status {status}!", exception.Message);
        }

        [Test]
        public void UpdateDoctorPassTest()
        {
            var doctor = doctorService.GetDoctorById(1);
            doctor.Name = "Pavithra Pazhanivel";
            var updatedDoctor = doctorService.UpdateDoctorByObject(doctor);
            Assert.IsNotNull(updatedDoctor);

        }
        [Test]
        public void UpdateDoctorExceptionTest()
        {
            Doctor doctor = new Doctor() { Id = 3, Name = "Pavi", Age = 35, PhoneNumber = "878978553", Experience = 10, Qualification = "MBBS", Specialization = "Neurologist", Appointments = { new Appointment(1, new DateTime(2024, 05, 03), "General checkup", "Not Completed") } };
            var exception = Assert.Throws<ObjectNotAvailableException>(() => doctorService.UpdateDoctorByObject(doctor));
            //Assert
            Assert.AreEqual($"Doctor with the id {doctor.Id} is not available!", exception.Message);
        }


        [Test]
        public void UpdateDoctorExperiencePassTest()
        {
            var result = doctorService.UpdateDoctorExperienceById(1, 15);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdateDoctorExperienceExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => doctorService.UpdateDoctorExperienceById(id, 10));
            Assert.AreEqual($"Doctor with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void UpdateDoctorNamePassTest()
        {
            var result = doctorService.UpdateDoctorNameById(1, "Pavithraaa");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdateDoctorNameExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => doctorService.UpdateDoctorNameById(id, "Shiva"));
            Assert.AreEqual($"Doctor with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void UpdateDoctorQualificationPassTest()
        {
            var result = doctorService.UpdateDoctorQualificationById(1, "MBBS,PHD");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdateDoctorQualificationExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => doctorService.UpdateDoctorQualificationById(id, "MBBS,PHD"));
            Assert.AreEqual($"Doctor with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void UpdateDoctorSPecializationPassTest()
        {
            var result = doctorService.UpdateDoctorSpecializationById(1, "Gynacologist");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdateDoctorSpecializationExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => doctorService.UpdateDoctorSpecializationById(id, "Neurologistsss"));
            Assert.AreEqual($"Doctor with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void UpdateDoctorPhoneNumberPassTest()
        {
            var result = doctorService.UpdateDoctorPhoneNumberById(1, "989765434");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdateDoctorEPhoneNumberExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => doctorService.UpdateDoctorPhoneNumberById(id, "978654345"));
            Assert.AreEqual($"Doctor with the id {id} is not available!", exception.Message);
        }
    }
}
