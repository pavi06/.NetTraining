using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemDALLibrary
{
    public class TransactionRepository : IRepository<int,TransactionForBooking>
    {
        public readonly Dictionary<int, TransactionForBooking> _transactions;

        public TransactionRepository()
        {
            _transactions = new Dictionary<int, TransactionForBooking>();
        }

        int GenerateId()
        {
            if (_transactions.Count == 0)
                return 1;
            int id = _transactions.Keys.Max();
            return ++id;
        }

        public TransactionForBooking Add(TransactionForBooking item)
        {
            if (_transactions.ContainsValue(item))
            {
                return null;
            }
            item.TransactionId = GenerateId();
            _transactions.Add(item.TransactionId, item);
            return item;
        }

        public TransactionForBooking Delete(int key)
        {
            if (_transactions.ContainsKey(key))
            {
                var transaction = _transactions[key];
                _transactions.Remove(key);
                return transaction;
            }
            return null;
        }

        public TransactionForBooking Get(int key)
        {
            return _transactions.ContainsKey(key) ? _transactions[key] : null;
        }

        public List<TransactionForBooking> GetAll()
        {
            if (_transactions.Count == 0)
                return null;
            return _transactions.Values.ToList();
        }

        public TransactionForBooking Update(TransactionForBooking item)
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
