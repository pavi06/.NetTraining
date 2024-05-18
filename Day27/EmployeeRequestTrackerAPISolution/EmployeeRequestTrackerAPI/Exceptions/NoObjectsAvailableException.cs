using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoObjectsAvailableException : Exception
    {
     
        public NoObjectsAvailableException(string? message) : base(message)
        {
        }
    }
}