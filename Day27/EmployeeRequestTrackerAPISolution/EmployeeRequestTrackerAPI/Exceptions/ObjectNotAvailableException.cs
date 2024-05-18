using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class ObjectNotAvailableException : Exception
    {
        public ObjectNotAvailableException(string? message) : base(message)
        {
        }

    }
}