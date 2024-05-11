using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerModelLibrary
{
    public class Request
    {
        [Key]
        //either represent key here or can be done in context with HasKey()
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }


        public int RequestRaisedBy { get; set; }

        public Employee RaisedByEmployee { get; set; } //navigation

        public int RequestClosedBy { get; set; }

        public Employee RequestClosedByEmployee { get; set; } //navigation

        public ICollection<RequestSolution> RequestSolutions { get; set; } //navigation
    }
}
