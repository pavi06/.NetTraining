using ERequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerBLLLibrary
{
    public interface IEmployeeAdminBL
    {
        public Task<List<RequestSolution>> ViewAllSolutionsProvided();
        public Task<List<RequestSolution>> GetAllSolutionsForAdmin();
        public Task<RequestSolution> ProvideSolutionForRequestRaised(RequestSolution reqSolution);
        public Task<List<SolutionFeedback>> ViewFeedbacks();
        public Task GetAllRequestAndUpdate();
        public Task<Request> UpdateRequestForClosure(int reqId, int reqSolId);
        public Task<List<Request>> GetAllRequest();
        public Task UpdateRequestRaisedByThem(int reqId);
    }
}
