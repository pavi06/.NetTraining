namespace ClinicTrackerAPI.Exceptions
{
    public class NoDoctorsAvailableException : Exception
    {
        string msg = "";
        public NoDoctorsAvailableException(string message)
        {
            msg = $"No Doctors Available {message}!";
        }

        public override string Message => msg;
    }
}
