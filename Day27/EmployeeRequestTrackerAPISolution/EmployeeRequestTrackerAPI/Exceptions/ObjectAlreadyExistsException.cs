using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class ObjectAlreadyExistsException : Exception
    {
        public ObjectAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}