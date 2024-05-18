using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IEmployeeRequestService
    {
        public Task<RequestReturnDTO> RaiseRequest(string requestMessage, int userId);
        public Task<List<RequestReturnDTO>> GetAllRequestRaisedByEmployee(int userId);
        public Task<RequestReturnDTO> GetRequestRaised(int reqId, int userId);
    }
}
