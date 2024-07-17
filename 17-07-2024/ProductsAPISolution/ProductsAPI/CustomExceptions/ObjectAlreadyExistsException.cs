namespace ProductsAPI.CustomExceptions
{
    public class ObjectAlreadyExistsException : Exception
    {
        public string msg = "";
        public ObjectAlreadyExistsException(string message) {
            msg = $"{message} already exists!";
        }

        public override string Message => msg;
    }
}
