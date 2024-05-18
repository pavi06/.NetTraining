using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; } = "Open";

        public int RequestRaisedBy { get; set; }
        public Employee RaisedByEmployee { get; set; }

        public int? RequestClosedBy { get; set; } = null;
        public Employee RequestClosedByEmployee { get; set; }

        public Request( int requestRaisedBy, string requestMessage)
        {
            RequestMessage = requestMessage;
            RequestRaisedBy = requestRaisedBy;
        }
    }
}
