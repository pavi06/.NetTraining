namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class RequestDTO
    {
        public int RequestId { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestStatus { get; set; }
        public int RequestRaisedBy { get; set; }

        public RequestDTO(int requestId, string requestMessage, DateTime requestDate, string requestStatus, int requestRaisedBy)
        {
            RequestId = requestId;
            RequestMessage = requestMessage;
            RequestDate = requestDate;
            RequestStatus = requestStatus;
            RequestRaisedBy = requestRaisedBy;
        }
    }
}
