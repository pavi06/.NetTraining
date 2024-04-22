using BusBookingSystemModelLibrary;
using System.Numerics;

namespace BusBookingSystemDALLibrary
{
    public class BusRepository : IRepository<int, Bus>
    {
        public readonly Dictionary<int, Bus> _buses;

        public BusRepository()
        {
            _buses = new Dictionary<int, Bus>();
        }

        int GenerateId()
        {
            if (_buses.Count == 0)
                return 1;
            int id = _buses.Keys.Max();
            return ++id;
        }

        public Bus Add(Bus item)
        {
            if (_buses.ContainsValue(item))
            {
                return null;
            }
            item.BusId = GenerateId();
            _buses.Add(item.BusId, item);
            return item;
        }

        public Bus Delete(int key)
        {
            if (_buses.ContainsKey(key))
            {
                var bus = _buses[key];
                _buses.Remove(key);
                return bus;
            }
            return null;
        }

        public Bus Get(int key)
        {
            return _buses.ContainsKey(key) ? _buses[key] : null;
        }

        public List<Bus> GetAll()
        {
            if (_buses.Count == 0)
                return null;
            return _buses.Values.ToList();
        }

        public Bus Update(Bus item)
        {
            if (_buses.ContainsKey(item.BusId))
            {
                _buses[item.BusId] = item;
                return item;
            }
            return null;
        }
    }
}
