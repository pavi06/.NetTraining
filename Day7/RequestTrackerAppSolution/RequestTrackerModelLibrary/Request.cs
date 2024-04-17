using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    //Iequatable is the interface where u can check the equality of generic obj.
    //instead of overloading can make use of this interface.
    public class Request : IEquatable<Request>
    {
        public int Id { get; set; }
        public string RequestText { get; set; }
        public int Raised_By { get; set; }
        public string Status { get; set; }
        public int Closed_By { get; set; }

        //by default the date will be assigned if any request is made.
        //can also assign the value through default constructor
        public DateTime RaisedDate { get; set; } = DateTime.Now;
        public DateTime ClosedDate { get; set; }

        //public bool Equals(Request? other)
        //{
        //    return Id.Equals(other.Id);
        //}
        public bool Equals(Request? other) => Id.Equals(other.Id);
    }
}
