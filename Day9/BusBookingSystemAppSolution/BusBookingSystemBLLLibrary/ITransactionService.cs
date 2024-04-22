using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary
{
    public interface ITransactionService
    {
        int AddTransaction(TransactionForBooking transaction);
        TransactionForBooking GetTransactionById(int id);
        List<TransactionForBooking> GetAllTransactions();
        List<TransactionForBooking> GetAllTransactionsByStatus(string transactionStatus);
        List<TransactionForBooking> GetAllTransactionsByType(string transactionType);
        List<TransactionForBooking> GetAllTransactionsByDate(DateTime date);
        TransactionForBooking DeleteTransactionById(int id);
        TransactionForBooking UpdateTransactionByObject(TransactionForBooking transaction);
        bool UpdateTransactionStatusById(int id, string status);
    }
}
