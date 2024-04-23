using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLLibrary.CustomExceptions
{
    public class ObjectIsNotAssociatedWithAppointmentException : Exception
    {
        string msg = "";
        public ObjectIsNotAssociatedWithAppointmentException(string message, int objId, int id)
        {
            msg = $"{message} - id {objId} is not associated with the Appointment - id {id}!";
        }
        public override string Message => msg;
    }
}
