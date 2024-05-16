using System.Runtime.Serialization;

namespace PizzaShopAPI.Exceptions
{
    [Serializable]
    internal class ObjectAlreadyExistsException : Exception
    {
        public ObjectAlreadyExistsException()
        {
        }

        public ObjectAlreadyExistsException(string? message) : base(message)
        {
        }

        public ObjectAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ObjectAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}