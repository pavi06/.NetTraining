using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Repositories;

namespace EmployeeRequestTrackerAPI.Services
{
    public class EmployeeRequestService : IEmployeeRequestService
    {
        protected readonly IRepository<int, Request> _reqRepository;
        protected readonly IRepository<int, Employee> _empRequestRepository;
        private readonly IUserService _userService;

        public EmployeeRequestService(IRepository<int, Request> requestRepository, IRepository<int, Employee> empRequestRepository, IUserService userService) {
            _reqRepository = requestRepository;
            _empRequestRepository = empRequestRepository;
            _userService = userService;
        }

        public async Task<List<RequestReturnDTO>> GetAllRequestRaisedByEmployee(int id)
        {
            var empReqRaisedList = _empRequestRepository.Get(id).Result.RequestsRaised.ToList();
            if (empReqRaisedList.Count > 0)
            {
                List<RequestReturnDTO> requests = new List<RequestReturnDTO>();
                foreach (var req in empReqRaisedList)
                {
                    requests.Add(new RequestReturnDTO(req.RequestId, req.RequestMessage, req.RequestStatus));
                }
                return requests;
            }
            throw new NoObjectsAvailableException($"No Requests were raised by the employee - {id}");
        }

        public async Task<RequestReturnDTO> GetRequestRaised(int reqId, int userID)
        {
            var request = await _reqRepository.Get(reqId);
            if (request != null)
            {
                if (request.RequestRaisedBy != userID)
                    throw new Exception("Request was not raised by you!");
                RequestReturnDTO req = new RequestReturnDTO(request.RequestId,request.RequestMessage,request.RequestStatus);
                return req;
            }
            throw new ObjectNotAvailableException($"Request with id - {reqId} is not available!");
        }

        public async Task<RequestReturnDTO> RaiseRequest(string requestMessage, int loggedUserId)
        {
            Request request = new Request(loggedUserId,requestMessage);
            var reqRaised = await _reqRepository.Add(request);
            if (reqRaised != null)
            {
                RequestReturnDTO requestRaisedDTO = new RequestReturnDTO(reqRaised.RequestId,reqRaised.RequestMessage,reqRaised.RequestStatus); 
                return requestRaisedDTO;
            }
            throw new ObjectAlreadyExistsException("Request Already raised!");
        }
    }
}
