namespace ProductsAPI.CustomExceptions
{
    public class NoSuchObjectAvailableException : Exception
    {
        public string message = "";
        public NoSuchObjectAvailableException(string msg) { 
            message = $"{msg} not available!";
        }

        public override string Message => message;
    }
}
