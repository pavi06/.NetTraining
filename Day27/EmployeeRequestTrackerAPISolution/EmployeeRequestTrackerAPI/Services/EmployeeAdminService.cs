using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Repositories;

namespace EmployeeRequestTrackerAPI.Services
{
    public class EmployeeAdminService : IEmployeeAdminService
    {
        protected readonly IRepository<int, Request> _reqRepository;

        public EmployeeAdminService(IRepository<int, Request> requestRepository) {
            _reqRepository = requestRepository;
        }

        public async Task<IList<RequestDTO>> GetAllRequest()
        {
            var allRequests = _reqRepository.Get().Result.Where(r=>r.RequestStatus=="Open").OrderBy(r=>r.RequestDate).ToList();
            if (allRequests != null)
            {
                List<RequestDTO> requests = new List<RequestDTO>();
                foreach (var request in allRequests)
                {
                    RequestDTO req = new RequestDTO(request.RequestId,request.RequestMessage,request.RequestDate,request.RequestStatus,request.RequestRaisedBy);
                    requests.Add(req);
                }
                return requests;
            }
            throw new NoObjectsAvailableException("No Request were raised!");
        }
    }
}
