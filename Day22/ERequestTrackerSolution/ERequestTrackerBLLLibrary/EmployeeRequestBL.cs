using ERequestTrackerBLLLibrary.CustomExceptions;
using ERequestTrackerDALLibrary;
using ERequestTrackerModelLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerBLLLibrary
{
    public class EmployeeRequestBL : IEmployeeRequestBL
    {
        protected RequestSolutionRepository _requestSolutionRepo;
        protected RequestRepository _reqRepo;
        protected SolutionFeedbackRepository _solutionFeedbackRepo;
        protected RequestTrackerContext _reqTrackerContext;
        protected Employee LoggedUser;

        public EmployeeRequestBL(Employee user) {
            _reqTrackerContext = new RequestTrackerContext();   
            _requestSolutionRepo = new RequestSolutionRepository(_reqTrackerContext);
            _reqRepo = new RequestRepository(_reqTrackerContext);
            _solutionFeedbackRepo = new SolutionFeedbackRepository(_reqTrackerContext);
            LoggedUser = user;
        }
        public async Task<List<Request>> GetAllRequestRaisedByEmployee()
        {
            var empReqRaisedList = _reqRepo.GetAll().Result.Where(r=>r.RequestRaisedBy == LoggedUser.Id).ToList();
            if(empReqRaisedList.Count > 0)
            {
                return empReqRaisedList;
            }
            throw new NoObjectsAvailableException($"No Requests were raised by the employee - {LoggedUser.Id}");
        }

        public async Task<List<RequestSolution>> GetAllSolutionsForTheRequestRaised(int reqId)
        {
            var solutionsProvided = _requestSolutionRepo.GetAll().Result.ToList().Where(rs => rs.RequestId == reqId).ToList();  
            if(solutionsProvided.Count > 0)
                return solutionsProvided.ToList();
            throw new NoObjectsAvailableException($"No solutions were provided till now for the request id - {reqId}");

        }

        public async Task<List<RequestSolution>> GetAllSolutionsForTheRequestRaisedUnSeen(int reqId)
        {
            var solutionsUnseen = GetAllSolutionsForTheRequestRaised(reqId).Result.Where(rs => rs.RequestRaiserComment == null);
            if (solutionsUnseen != null)
            {
                return solutionsUnseen.ToList();
            }
            throw new ObjectNotAvailableException("No solutions were provided yet!");
        }

        public async Task<Request> GetRequestRaised(int reqId)
        {
            var request =  await _reqRepo.Get(reqId);
            if(request != null)
            {
                return request; 
            }
            throw new ObjectNotAvailableException($"Request with id - {reqId} is not available!");
        }

        public async Task<int> RaiseRequest(Request request)
        {
            request.RequestRaisedBy = LoggedUser.Id;
            var reqRaised = await _reqRepo.Add(request);
            if (reqRaised != null )
            {
                return reqRaised.RequestNumber;
            }
            return -1;
        }

        public async Task<string> RespondToSolutionProvided(int solId,string comment)
        {
            var sol = await _requestSolutionRepo.Get(solId);
            if(sol != null)
            {
                sol.RequestRaiserComment = comment;
                if (await _requestSolutionRepo.Update(sol) != null)
                {
                    return "Comment added successfully";
                }
                throw new ObjectNotAvailableException($"Solution - {solId} for the request is not available");
            }
            throw new ObjectNotAvailableException($"Solution - {solId} for the request is not available");
        }

        public async Task<string> GiveFeedback(SolutionFeedback feedback)
        {
            feedback.FeedbackBy = LoggedUser.Id; 
            if (await _solutionFeedbackRepo.Add(feedback)!= null)
            {
                return "Your Feedback added sucessfully! Thank you!";
            }
            return "Your feedback is not added successfully"; 
        }

        public Task<RequestSolution> GetSolutionByKey(int solId)
        {
            var sol = _requestSolutionRepo.Get(solId);
            if(sol != null )
            {
                return sol;
            }
            throw new ObjectNotAvailableException($"Solution with id - {solId} is not available!");
        }

        public async Task<bool> CheckRequestRaisedByEmployeeOrNot(int solId)
        {
            try
            {
                var req = GetRequestRaised(GetSolutionByKey(solId).Result.RequestId).Result.RequestRaisedBy == LoggedUser.Id;
                if (req)
                {
                    return true;
                }
                return false;
            }
            catch(ObjectNotAvailableException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            }
            throw new ObjectNotAvailableException("");
        }

        public async Task<bool> CheckObjectAvailableOrNot(string objType, int id)
        {
            if(objType.ToLower() == "request")
            {
                if (await _reqRepo.Get(id) != null)
                    return true;
                else
                    return false;
            }
            else if (objType.ToLower() == "solution")
            {
                if (await _requestSolutionRepo.Get(id) != null)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
