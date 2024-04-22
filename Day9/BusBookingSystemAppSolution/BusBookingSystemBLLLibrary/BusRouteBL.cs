using BusBookingSystemBLLLibrary.CustomExceptions;
using BusBookingSystemDALLibrary;
using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary
{
    public class BusRouteBL : IBusRouteService
    {
        readonly IRepository<int, BusRoute> _busRouteRepository;
        public BusRouteBL()
        {
            _busRouteRepository = new BusRouteRepository();
        }
        public int AddBusRoute(BusRoute busRoute)
        {
            var busRouteAdded = _busRouteRepository.Add(busRoute);
            if (busRouteAdded != null)
            {
                return busRouteAdded.RouteId;
            }
            throw new ObjectAlreadyExistsException("Current BusRoute Already Exists!");
        }

        public BusRoute DeleteBusRouteById(int id)
        {
            var busRoute = _busRouteRepository.Get(id);
            if (busRoute != null)
            {
                return busRoute;
            }
            throw new ObjectNotAvailableException($"BusRoute with the id {id} is not available!");
        }

        public List<BusRoute> GetAllBusRoute()
        {
            var busRouteList = _busRouteRepository.GetAll();
            if (busRouteList != null)
            {
                return busRouteList;
            }
            throw new NoBusRoutesAvailableException("");
        }

        public BusRoute GetBusRouteById(int id)
        {
            var busRoute = _busRouteRepository.Get(id);
            if (busRoute != null) {
                return busRoute;
            }
            throw new ObjectNotAvailableException($"BusRoute with the id {id} is not available!");

        }
        public List<Bus> GetAllBusWithBusRouteId(int id)
        {
            var busList = GetBusRouteById(id)._buses;
            if (busList != null) {
                return busList;
            }
            throw new NoBusAvailableException($"with busroute - id {id}");
        }

        public string GetBusRouteDestinationPointById(int id)
        {
            string destinationPoint = GetBusRouteById(id).RouteDestinationPoint;
            if (destinationPoint != null) {
                return destinationPoint;
            }
            throw new NullValueException("");
        }

        public string GetBusRouteSourcePointById(int id)
        {
            string sourcePoint = GetBusRouteById(id).RouteSourcePoint;
            if (sourcePoint != null)
            {
                return sourcePoint;
            }
            throw new NullValueException("");
        }

        public BusRoute UpdateBusRouteByObject(BusRoute busRoute)
        {
            var busRouteUpdated = _busRouteRepository.Update(busRoute);
            if (busRouteUpdated != null)
            {
                return busRouteUpdated;
            }
            throw new ObjectNotAvailableException($"BusRoute with the id {busRoute.RouteId} is not available!");
        }

        public bool UpdateBusRouteDestinationPointById(int id, string destination)
        {
            var busRoute = GetBusRouteById(id);
            busRoute.RouteDestinationPoint = destination;
            if (UpdateBusRouteByObject(busRoute) != null)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool UpdateBusRouteNameById(int id, string routeName)
        {
            var busRoute = GetBusRouteById(id);
            busRoute.RouteName = routeName;
            if (UpdateBusRouteByObject(busRoute) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateBusRouteSourcePointById(int id, string source)
        {
            var busRoute = GetBusRouteById(id);
            busRoute.RouteSourcePoint = source;
            if (UpdateBusRouteByObject(busRoute) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Bus> GetAllBusByDestination(string destination)
        {
            var busRoutes = GetAllBusRoute();
            List<Bus> buses;
            foreach (BusRoute busRoute in busRoutes) {
                if (busRoute.RouteDestinationPoint == destination) {
                     buses = busRoute._buses;
                     return buses;
                }
            }
            return new List<Bus>();

        }
    }
}
