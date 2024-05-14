namespace ClinicTrackerAPI.Exceptions
{
    public class NoSuchDoctorAvailableException : Exception
    {
        string msg = "";
        public NoSuchDoctorAvailableException()
        {
            msg = "No such doctor exists!";
        }

        public override string Message => msg;
    }
}
