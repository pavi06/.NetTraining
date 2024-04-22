using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemModelLibrary
{
    public class Transaction
    {
        private int TransactionId { get; set; }
        private string TransactionMode { get; set; } = string.Empty;
        private string TransactionType { get; set; } = string.Empty;
        private string TransactionDescription { get; set; } = string.Empty;
        public string TransactionStatus { get; set; } = string.Empty;
        private DateTime TransactionDate { get; set; } = DateTime.Now;

        public Transaction(int transactionId, string transactionMode, string transactionType, string transactionDescription, string transactionStatus, DateTime transactionDate, Passenger passenger)
        {
            TransactionId = transactionId;
            TransactionMode = transactionMode;
            TransactionType = transactionType;
            TransactionDescription = transactionDescription;
            TransactionStatus = transactionStatus;
            TransactionDate = transactionDate;
        }

        public override string ToString()
        {
            return $"----------Transaction Details---------\nTransaction Id : {TransactionId}\nTransaction Type : {TransactionType}\nTransaction Status : {TransactionStatus}";
        }
    }
}
