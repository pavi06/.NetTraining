using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemDALLibrary
{
    public class PassengerRepository : IRepository<int, Passenger>
    {
        public readonly Dictionary<int, Passenger> _passengers;

        public PassengerRepository()
        {
            _passengers = new Dictionary<int, Passenger>();
        }

        int GenerateId()
        {
            if (_passengers.Count == 0)
                return 1;
            int id = _passengers.Keys.Max();
            return ++id;
        }
        public Passenger Add(Passenger item)
        {
            if (_passengers.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _passengers.Add(item.Id, item);
            return item;
        }

        public Passenger Delete(int key)
        {
            if (_passengers.ContainsKey(key))
            {
                var passenger = _passengers[key];
                _passengers.Remove(key);
                return passenger;
            }
            return null;
        }

        public Passenger Get(int key)
        {
            return _passengers.ContainsKey(key) ? _passengers[key] : null;
        }

        public List<Passenger> GetAll()
        {
            if (_passengers.Count == 0)
                return null;
            return _passengers.Values.ToList();
        }

        public Passenger Update(Passenger item)
        {
            if (_passengers.ContainsKey(item.Id))
            {
                _passengers[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
