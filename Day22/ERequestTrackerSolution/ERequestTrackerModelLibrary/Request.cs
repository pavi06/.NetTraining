using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERequestTrackerModelLibrary
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; } = "Open";

        public int RequestRaisedBy { get; set; }

        public Employee RaisedByEmployee { get; set; } //navigation

        public int? RequestClosedBy { get; set; } = null;

        public Employee RequestClosedByEmployee { get; set; } //navigation

        public ICollection<RequestSolution> RequestSolutions { get; set; } //navigation

        public override string ToString()
        {
            return $"Request Number : {RequestNumber}, RequestMessage : {RequestMessage}, Request Date : {RequestDate}, " +
                $"Request raised by : {RequestRaisedBy}, Request status : {RequestStatus}, Request closed by : {RequestClosedBy}";
        }

    }
}
