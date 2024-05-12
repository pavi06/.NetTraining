using ERequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerBLLLibrary
{
    public interface IEmployeeRequestBL
    {
        public Task<int> RaiseRequest(Request request);
        public Task<List<Request>> GetAllRequestRaisedByEmployee();
        public Task<Request> GetRequestRaised( int reqId);
        public Task<RequestSolution> GetSolutionByKey(int solId);
        public Task<List<RequestSolution>> GetAllSolutionsForTheRequestRaised(int reqId);
        public Task<List<RequestSolution>> GetAllSolutionsForTheRequestRaisedUnSeen(int reqId);
        public Task<bool> CheckRequestRaisedByEmployeeOrNot(int solId);
        public Task<string> GiveFeedback(SolutionFeedback feedback);
        public Task<string> RespondToSolutionProvided(int solId, string comment);
        public Task<bool> CheckObjectAvailableOrNot(string objType, int solId);
    }
}
