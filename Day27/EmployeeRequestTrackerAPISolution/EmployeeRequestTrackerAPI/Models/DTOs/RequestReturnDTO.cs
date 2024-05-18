namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class RequestReturnDTO
    {
        public int RequestId { get; set; }
        public string RequestMessage { get; set; }
        public string RequestStatus { get; set; }

        public RequestReturnDTO(int requestId, string requestMessage, string requestStatus)
        {
            RequestId = requestId;
            RequestMessage = requestMessage;
            RequestStatus = requestStatus;
        }
    }
}
