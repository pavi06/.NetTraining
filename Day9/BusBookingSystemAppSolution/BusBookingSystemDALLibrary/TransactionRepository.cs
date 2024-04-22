using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemDALLibrary
{
    public class TransactionRepository : IRepository<int,Transaction>
    {
        public readonly Dictionary<int, Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new Dictionary<int, Transaction>();
        }

        int GenerateId()
        {
            if (_transactions.Count == 0)
                return 1;
            int id = _transactions.Keys.Max();
            return ++id;
        }

        public Transaction Add(Transaction item)
        {
            if (_transactions.ContainsValue(item))
            {
                return null;
            }
            item.TransactionId = GenerateId();
            _transactions.Add(item.TransactionId, item);
            return item;
        }

        public Transaction Delete(int key)
        {
            if (_transactions.ContainsKey(key))
            {
                var transaction = _transactions[key];
                _transactions.Remove(key);
                return transaction;
            }
            return null;
        }

        public Transaction Get(int key)
        {
            return _transactions.ContainsKey(key) ? _transactions[key] : null;
        }

        public List<Transaction> GetAll()
        {
            if (_transactions.Count == 0)
                return null;
            return _transactions.Values.ToList();
        }

        public Transaction Update(Transaction item)
        {
            if (_transactions.ContainsKey(item.TransactionId))
            {
                _transactions[item.TransactionId] = item;
                return item;
            }
            return null;
        }
    }
}
