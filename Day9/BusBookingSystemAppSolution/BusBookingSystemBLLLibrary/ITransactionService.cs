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
        int AddTransaction(Transaction transaction);
        Transaction GetTransactionById(int id);
        List<Transaction> GetAllTransactions(int id);
        List<Transaction> GetAllTransactionsByStatus(string transactionStatus);
        List<Transaction> GetAllTransactionsByType(string transactionType);
        List<Transaction> GetAllTransactionsByDate(DateTime date);
        Transaction DeleteTransactionById(int id);
        Transaction UpdateTransactionByObject(Transaction transaction);
        bool UpdateTransactionStatusById(int id, string status);
    }
}
