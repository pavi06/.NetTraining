using ClinicTrackerBLLLibrary;
using ClinicTrackerBLLLibrary.CustomExceptions;
using ClinicTrackerDALLibrary;
using ClinicTrackerDALLibrary.Model;

namespace ClinicTrackerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatientRepository patientRepository = new PatientRepository();
            PatientBL patientBl = new PatientBL(patientRepository);
            try
            {
                //dbClinicContext context = new dbClinicContext();
                //Console.WriteLine(context.Patients.GetType()); 
                //var patients = context.Patients.ToList();
                //foreach (var pat in patients)
                //{
                //    Console.WriteLine(pat.ToString());
                //}

                //Patient patient = new Patient() { PatientName = "Sai", Age = 15, Gender = "Male", ContactAddress = "Chennai", BloodGroup = "A+ve", PhoneNumber = "7857453434" };
                //var addedPatient = patientBl.AddPatient(patient);
                //Console.WriteLine("Patient Added Successfully!");
                var patientObject = patientBl.GetPatientById(1);
                Console.WriteLine(patientObject.ToString());
                //if(patientBl.UpdatePatientAddressById(2,"Korattur chennai"))
                //{
                //    Console.WriteLine("Patient Updated successfully!");
                //}
                //var patient = patientBl.DeletePatientById(6);
                //Console.WriteLine(patient.ToString());
            }
            catch (ObjectAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ObjectNotAvailableException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
