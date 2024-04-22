using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemModelLibrary
{
    public class TransactionForBooking
    {
        public int TransactionId { get; set; }
        public string TransactionMode { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public string TransactionDescription { get; set; } = string.Empty;
        public string TransactionStatus { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public TransactionForBooking(int transactionId, string transactionMode, string transactionType, string transactionDescription, string transactionStatus)
        {
            TransactionId = transactionId;
            TransactionMode = transactionMode;
            TransactionType = transactionType;
            TransactionDescription = transactionDescription;
            TransactionStatus = transactionStatus;
        }

        public override string ToString()
        {
            return $"----------Transaction Details---------\nTransaction Id : {TransactionId}\nTransaction Type : {TransactionType}\nTransaction Status : {TransactionStatus}";
        }
    }
}
