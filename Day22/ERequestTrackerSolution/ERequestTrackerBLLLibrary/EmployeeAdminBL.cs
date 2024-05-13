using ERequestTrackerBLLLibrary;
using ERequestTrackerBLLLibrary.CustomExceptions;
using ERequestTrackerBLLLibrary.Exceptions;
using ERequestTrackerDALLibrary;
using ERequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerBLLLibrary
{
    public class EmployeeAdminBL : EmployeeRequestBL, IEmployeeAdminBL
    {
        protected RequestSolutionRepository _reqSolRepo;
        protected RequestRepository _requestRepository;
        protected Employee LoggedUser;
        protected RequestTrackerContext _reqTrackerContext;
        protected EmployeeAdminRepository _empAdminRepo;
  
        public EmployeeAdminBL(Employee user) : base(user){
            _reqTrackerContext = base._reqTrackerContext;
            _reqSolRepo = base._requestSolutionRepo;
            _requestRepository =base._reqRepo;
            _empAdminRepo = new EmployeeAdminRepository(_reqTrackerContext);
            LoggedUser = base.LoggedUser;
        }

        public async Task<List<Request>> GetAllRequest()
        {
            var allRequests = _requestRepository.GetAll().Result.ToList();
            if(allRequests != null)
            {
                return allRequests;
            }
            throw new NoObjectsAvailableException("No Request were raised!");
        }


        public async Task<RequestSolution> ProvideSolutionForRequestRaised(RequestSolution reqSolution)
        {
            reqSolution.SolvedBy = LoggedUser.Id;
            var solAdded = await _reqSolRepo.Add(reqSolution);
            if ( solAdded != null)
            {
                return solAdded;
            }
            throw new ObjectAlreadyExistsException("Solution already provided!");
        }

        public async Task<List<RequestSolution>> ViewAllSolutionsProvided()
        {
            var solutions = _empAdminRepo.Get(LoggedUser.Id).Result.SolutionsProvided.ToList();
            if (solutions.Count > 0)
            {
                return solutions;
            }
            throw new("No solutions were provided by you!");
        }

        public async Task<List<RequestSolution>> GetAllSolutionsForAdmin()
        {
            var getAllSolutions = new List<RequestSolution>();
            try
            {
                var requestsRaisedBy = await GetAllRequestRaisedByEmployee();
                foreach (var req in requestsRaisedBy)
                {
                    getAllSolutions.AddRange(await GetAllSolutionsForTheRequestRaised(req.RequestNumber));
                }
            }
            catch (NoObjectsAvailableException e) {}
            try
            {
                getAllSolutions.AddRange(await ViewAllSolutionsProvided());
            }
            catch (NoObjectsAvailableException e) {}
            if (getAllSolutions.Count > 0)
            {
                await Console.Out.WriteLineAsync("----Solutions----");
                return getAllSolutions;
            }
            throw new NoObjectsAvailableException("No solutions available !");
        }

        public async Task GetAllRequestAndUpdate()
        {
            var requestSolutions = ViewAllSolutionsProvided().Result.Where(rs => rs.IsSolved == false);
            var flag = true;
            foreach (var request in requestSolutions)
            {
                if (request.RequestRaiserComment != null && request.RequestRaiserComment.ToLower().Contains("solved") && !request.RequestRaiserComment.ToLower().Contains("not"))
                {
                    flag = false;
                    await Console.Out.WriteLineAsync(UpdateRequestForClosure(request.RequestId, request.SolutionId).Result.ToString());
                }
            }
            if (flag)
            {
                throw new NoObjectsAvailableException("No request available for update!");
            }
        }

        public async Task<Request> UpdateRequestForClosure(int reqId, int reqSolId)
        {
            var req = await _requestRepository.Get(reqId);
            if (req == null)
                throw new ObjectNotAvailableException($"Request - {reqId} is not available");
            var sol = await _reqSolRepo.Get(reqSolId);
            if (sol == null)
                throw new ObjectNotAvailableException($"Solution - {reqSolId} for the request - {reqId} is not available");       
            sol.IsSolved = true;
            req.ClosedDate = DateTime.Now;
            req.RequestStatus = "Closed";
            req.RequestClosedBy = LoggedUser.Id;
            await _reqSolRepo.Update(sol);
            if (await _requestRepository.Update(req) != null)
            {
                return req;
            }
            return null;
        }


        public async Task<List<SolutionFeedback>> ViewFeedbacks()
        {
            var reqSolutions = _reqSolRepo.GetAll().Result.ToList().FindAll(rs => rs.SolvedBy == LoggedUser.Id);
            List<SolutionFeedback> allFeedbacks = new List<SolutionFeedback>();
            foreach (var reqSolution in reqSolutions)
            {
                allFeedbacks.AddRange(reqSolution.Feedbacks);   
            }
            if (allFeedbacks.Count > 0)
            {
                return allFeedbacks;
            }
            throw new NoObjectsAvailableException("No feedbacks are provided to you!");
            
        }

        public async Task UpdateRequestRaisedByThem(int reqId)
        {
            try
            {
                var req = await GetRequestRaised(reqId);
                req.RequestClosedBy = LoggedUser.Id;
                req.RequestStatus = "closed";
                req.ClosedDate = DateTime.Now;
                if (await _reqRepo.Update(req) != null)
                {
                    await Console.Out.WriteLineAsync("Request Updated successfully!");
                }
            }
            catch (ObjectNotAvailableException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            }
        }
    }
}
