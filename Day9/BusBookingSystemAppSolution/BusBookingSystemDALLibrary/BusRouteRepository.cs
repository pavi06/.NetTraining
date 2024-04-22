using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemDALLibrary
{
    public class BusRouteRepository : IRepository<int,BusRoute>
    {
        public readonly Dictionary<int, BusRoute> _busRoutes;

        public BusRouteRepository()
        {
            _busRoutes = new Dictionary<int, BusRoute>();
        }

        int GenerateId()
        {
            if (_busRoutes.Count == 0)
                return 1;
            int id = _busRoutes.Keys.Max();
            return ++id;
        }

        public BusRoute Add(BusRoute item)
        {
            if(_busRoutes.ContainsValue(item))
            {
                return null;
            }
            item.RouteId = GenerateId();
            _busRoutes.Add(item.RouteId, item);
            return item;
        }

        public BusRoute Delete(int key)
        {
            if (_busRoutes.ContainsKey(key))
            {
                var busRoute = _busRoutes[key];
                _busRoutes.Remove(key);
                return busRoute;
            }
            return null;
        }

        public BusRoute Get(int key)
        {
            return _busRoutes.ContainsKey(key) ? _busRoutes[key] : null;
        }

        public List<BusRoute> GetAll()
        {
            if (_busRoutes.Count == 0)
                return null;
            return _busRoutes.Values.ToList();
        }

        public BusRoute Update(BusRoute item)
        {
            if (_busRoutes.ContainsKey(item.RouteId))
            {
                _busRoutes[item.RouteId] = item;
                return item;
            }
            return null;
        }
    }
}
