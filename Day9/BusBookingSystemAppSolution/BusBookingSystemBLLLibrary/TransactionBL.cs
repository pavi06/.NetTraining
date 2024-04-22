using BusBookingSystemBLLLibrary.CustomExceptions;
using BusBookingSystemDALLibrary;
using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusBookingSystemBLLLibrary
{
    public class TransactionBL : ITransactionService
    {
        readonly IRepository<int, TransactionForBooking> _transactionRepository;
        public TransactionBL()
        {
            _transactionRepository = new TransactionRepository();
        }
        public int AddTransaction(TransactionForBooking transaction)
        {
            var transactionAdded = _transactionRepository.Add(transaction);
            if (transactionAdded != null)
            {
                return transactionAdded.TransactionId;
            }
            throw new ObjectAlreadyExistsException("Current Transaction Already Exists!");
        }

        public TransactionForBooking DeleteTransactionById(int id)
        {
            var transaction = _transactionRepository.Get(id);
            if (transaction != null)
            {
                return transaction;
            }
            throw new ObjectNotAvailableException($"Transaction with the id {id} is not available!");
        }

        public List<TransactionForBooking> GetAllTransactions()
        {
            var transactionList = _transactionRepository.GetAll();
            if (transactionList != null)
            {
                return transactionList;
            }
            throw new NoTransactionAvailableException("");
        }

        public List<TransactionForBooking> GetAllTransactionsByDate(DateTime date)
        {
            var transactions = GetAllTransactions();
            foreach (var transaction in transactions)
            {
                if(transaction.TransactionDate != date)
                {
                    transactions.Remove(transaction);
                }
            }
            if (transactions.Count > 0) {
                return transactions; 
            }
            throw new NoTransactionAvailableException($"With the date - {date}"); 
        }

        public List<TransactionForBooking> GetAllTransactionsByStatus(string transactionStatus)
        {
            var transactions = GetAllTransactions();
            foreach (var transaction in transactions)
            {
                if (transaction.TransactionStatus != transactionStatus)
                {
                    transactions.Remove(transaction);
                }
            }
            if (transactions.Count > 0)
            {
                return transactions;
            }
            throw new NoTransactionAvailableException($"With the status - {transactionStatus}"); 
        }

        public List<TransactionForBooking> GetAllTransactionsByType(string transactionType)
        {
            var transactions = GetAllTransactions();
            foreach (var transaction in transactions)
            {
                if (transaction.TransactionType != transactionType)
                {
                    transactions.Remove(transaction);
                }
            }
            if (transactions.Count > 0)
            {
                return transactions;
            }
            throw new NoTransactionAvailableException($"With the status - {transactionType}"); ;
        }

        public TransactionForBooking GetTransactionById(int id)
        {
            var transaction = _transactionRepository.Get(id);
            if (transaction != null)
            {
                return transaction;
            }
            throw new ObjectNotAvailableException($"Transaction with the id {id} is not available!");
        }

        public TransactionForBooking UpdateTransactionByObject(TransactionForBooking transaction)
        {
            var transactionUpdated = _transactionRepository.Update(transaction);
            if (transactionUpdated != null) { 
                return transactionUpdated;
            }
            throw new ObjectNotAvailableException($"Transaction with the id {transaction.TransactionId} is not available!"); 
        }

        public bool UpdateTransactionStatusById(int id, string status)
        {
            var transaction = GetTransactionById(id);
            transaction.TransactionStatus = status;
            if (UpdateTransactionByObject(transaction) != null)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
