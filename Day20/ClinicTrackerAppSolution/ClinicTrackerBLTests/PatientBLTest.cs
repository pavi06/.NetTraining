using ClinicTrackerBLLLibrary;
using ClinicTrackerBLLLibrary.CustomExceptions;
using ClinicTrackerDALLibrary;
using ClinicTrackerDALLibrary.Model;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace ClinicTrackerBLTests
{
    public class PatientBLTest
    {
        IRepository<int, Patient> patientRepository;
        IPatientService patientService;

        [SetUp]
        public void Setup()
        {
            patientRepository = new PatientRepository();
            Patient patient = new Patient() { PatientName = "Pavithra", Age = 25, ContactAddress = "No.3 sai street, Korattur, Chennai", BloodGroup = "AB+ve", Gender = "Female", PhoneNumber = "9897654343" };
            patientRepository.Add(patient);
            patient = new Patient() { PatientName = "Sai", Age = 35, ContactAddress = "No.5 sai street, Korattur, Chennai", BloodGroup = "O+ve", Gender = "Male", PhoneNumber = "9897654343" };
            patientRepository.Add(patient);
            patientService = new PatientBL(patientRepository);
        }

        [Test]
        public void AddPatientPassTest()
        {
            //Arrange
            Patient patient = new Patient() { PatientName = "Sai" , Age = 35 , ContactAddress = "No.5 sai street, Korattur, Chennai", BloodGroup = "O+ve", Gender = "Female" , PhoneNumber = "9897654343"};
            //action
            var addedPatient = patientService.AddPatient(patient);
            //Assert
            Assert.IsNotNull(addedPatient);
        }

        [Test]
        public void AddPatientFailTest()
        {
            //Arrange
            Patient patient = new Patient() { Id = 1, PatientName = "Pavithra", Age = 25, ContactAddress = "No.3 sai street, Korattur, Chennai", BloodGroup = "AB+ve", Gender = "Female", PhoneNumber = "9897654343" };
            //action
            int addedPatient = -1;
            try {
                addedPatient = patientService.AddPatient(patient);
            }
            catch (ObjectAlreadyExistsException e) {
               
            }
            //Assert
            Assert.AreEqual(-1,addedPatient);
        }

        [Test]
        public void PatientAlreadyExistsExceptionTest()
        {
            Patient patient = new Patient() { Id = 1, PatientName = "Pavithra", Age = 25, ContactAddress = "No.3 sai street, Korattur, Chennai", BloodGroup = "AB+ve", Gender = "Female", PhoneNumber = "9897654343" };
            //Action
            var exception = Assert.Throws<ObjectAlreadyExistsException>(() => patientService.AddPatient(patient));
            //Assert
            Assert.AreEqual("Patient Already Exists!", exception.Message);
        }

        [Test]
        public void GetPatientPassTest()
        { 
            //action
            var patient = patientService.GetPatientById(1);
            //Assert
            Assert.IsNotNull(patient);
        }

        [Test]
        public void GetPatientFailTest()
        {
            //action
            Patient patient = null;
            try
            {
                patient = patientService.GetPatientById(3);
            }
            catch(ObjectNotAvailableException e)
            { 
            
            }
            //Assert
            Assert.IsNull (patient);
        }

        [Test]
        public void PatientNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => patientService.GetPatientById(id));
            //Assert
            Assert.AreEqual($"Patient with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void DeletePatientPassTest()
        {
            //action
            var patient = patientService.DeletePatientById(1);
            //Assert
            Assert.IsNotNull(patient);
        }

        [Test]
        public void DeletePatientFailTest()
        {
            //action
            Patient patient = null;
            try
            {
                patient = patientService.DeletePatientById(4);
            }
            catch (ObjectNotAvailableException e) { }
            //Assert
            Assert.IsNull(patient);
        }

        [Test]
        public void DeletePatientNotAvailableExceptionTest()
        {
            //Action
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => patientService.DeletePatientById(id));
            //Assert
            Assert.AreEqual($"Patient with the id {id} is not available!", exception.Message);
        }


        [Test]
        public void UpdatePatientPassTest() { 
            var patient = patientService.GetPatientById(1);
            patient.PatientName = "Pavithra Pazhanivel";
            var updatedPatient = patientService.UpdatePatientByObject(patient);
            Assert.IsNotNull(updatedPatient);
        }

        [Test]
        public void UpdatePatientFailTest()
        {
            Patient updatedPatient =null;
            try {
                Patient patient = new Patient() { Id = 3, PatientName = "Pavithra", Age = 25, ContactAddress = "No.3 sai street, Korattur, Chennai", BloodGroup = "AB+ve", Gender = "Female", PhoneNumber = "9897654343" };
                patient.PatientName = "Pavithra Pazhanivel";
                updatedPatient = patientService.UpdatePatientByObject(patient);
            }
            catch (ObjectNotAvailableException e) { }           
            Assert.IsNull(updatedPatient);
        }

        [Test]
        public void UpdatePatientExceptionTest()
        {
            Patient patient = new Patient() {Id=3, PatientName = "Pavithra Pazhanivel", Age = 25, ContactAddress = "No.3 sai street, Korattur, Chennai", BloodGroup = "AB+ve", Gender = "Female", PhoneNumber = "9897654343" };
            var exception = Assert.Throws<ObjectNotAvailableException>(() => patientService.UpdatePatientByObject(patient));
            //Assert
            Assert.AreEqual($"Patient with the id {patient.Id} is not available!", exception.Message);
        }

        [Test]
        public void UpdatePatientAddressPassTest() {
            var result = patientService.UpdatePatientAddressById(1, "No.4 shiva street, Korattur");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdatePatientAddressFailTest()
        {
            bool result = false;
            try
            {
                result = patientService.UpdatePatientAddressById(3, "No.4 shiva street, Korattur");
            }
            catch (Exception e) { }
            Assert.AreEqual(false,result);
        }

        [Test]
        public void UpdatePatientAddressExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => patientService.UpdatePatientAddressById(id,"no.4 chennai"));
            Assert.AreEqual($"Patient with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void UpdatePatientAgePassTest()
        {
            var result = patientService.UpdatePatientAgeById(1, 45);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdatePatientAgeFailTest()
        {
            bool result = false;
            try
            {
                result = patientService.UpdatePatientAgeById(3, 40);
            }
            catch (Exception e) { }
            Assert.AreEqual(false, result);
        }

        [Test]
        public void UpdatePatientAgeExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => patientService.UpdatePatientAgeById(id, 45));
            Assert.AreEqual($"Patient with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void UpdatePatientNamePassTest()
        {
            var result = patientService.UpdatePatientNameById(1, "Pavi");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdatePatientNameFailTest()
        {
            bool result = false;
            try
            {
                result = patientService.UpdatePatientNameById(3, "Pavi");
            }
            catch (Exception e) { }
            Assert.AreEqual(false, result);
        }

        [Test]
        public void UpdatePatientNameExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => patientService.UpdatePatientNameById(id, "Pavi"));
            Assert.AreEqual($"Patient with the id {id} is not available!", exception.Message);
        }

        [Test]
        public void UpdatePatientPhoneNumberPassTest()
        {
            var result = patientService.UpdatePatientPhoneNumberById(1, "97876564534");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void UpdatePatientPhoneNumberFailTest()
        {
            bool result = false;
            try
            {
                result = patientService.UpdatePatientPhoneNumberById(3, "9786756453435");
            }
            catch (Exception e) { }
            Assert.AreEqual(false, result);
        }

        [Test]
        public void UpdatePatientPhoneNumberExceptionTest()
        {
            int id = 3;
            var exception = Assert.Throws<ObjectNotAvailableException>(() => patientService.UpdatePatientPhoneNumberById(id, "8976564343"));
            Assert.AreEqual($"Patient with the id {id} is not available!", exception.Message);
        }
    }
}