using BusBookingSystemBLLLibrary.CustomExceptions;
using BusBookingSystemDALLibrary;
using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary
{
    internal class BusBL : IBusService
    {
        readonly IRepository<int, Bus> _busRepository;
        public BusBL()
        {
            _busRepository = new BusRepository();
        }
        public int AddBus(Bus bus)
        {
            var busAdded = _busRepository.Add(bus);
            if (busAdded != null)
            {
                return busAdded.BusId;
            }
            throw new ObjectAlreadyExistsException("Current Bus Already Exists!");
        }

        public Bus DeleteBusById(int id)
        {
            var bus = _busRepository.Get(id);
            if (bus != null)
            {
                return bus;
            }
            throw new ObjectNotAvailableException($"Bus with the id {id} is not available!"); 
        }

        public List<Bus> GetAllBus()
        {
            var busList = _busRepository.GetAll();
            if (busList != null) { 
                return busList;
            }
            throw new NoBusAvailableException("");
        }

        public List<Bus> GetAllBusByDepartureTime(DateTime time)
        {
            var busList = GetAllBus();
            foreach(var bus in busList)
            {
                if (bus.DepartureTime != time) { 
                    busList.Remove(bus);
                }
            }
            if(busList.Count>0)
            {
                return busList;
            }
            throw new NoBusAvailableException($"with departure time {time}");
        }
        public Bus GetBusById(int id)
        {
            var bus = _busRepository.Get(id);
            if(bus != null)
            {
                return bus;
            }
            throw new ObjectNotAvailableException($"Bus with the id {id} is not available!"); 
        }

        public List<Passenger> GetAllPassengersByBusId(int id)
        {
            var passengers = GetBusById(id).Passenger;
            if(passengers != null)
            {
                return passengers;
            }
            throw new NoPassengersAvailableException($"for bus - id {id}");
        }


        public BusRoute GetBusRouteByBusId(int id)
        {
            var busRoute = GetBusById(id).BusRoute;
            if (busRoute != null)
            {
                return busRoute;
            }
            throw new ObjectNotAvailableException($"BusRoute with the bus id {id} is not associated!"); 
        }

        public int GetNoOfSeatsAvailableForBusById(int id)
        {
            var seatsAvailable = GetBusById(id).NoOfSeatsAvailable;
            return seatsAvailable;
        }

        public int GetNoOfSeatsBookedForBusById(int id)
        {
            var bus = GetBusById(id);
            var seatsBooked = bus.TotalNoOfSeats - bus.NoOfSeatsAvailable;
            return seatsBooked;
        }
        public Bus UpdateBusByObject(Bus bus)
        {
            var updatedBus = _busRepository.Update(bus);
            if (updatedBus != null) { 
                return updatedBus;
            }
            throw new ObjectNotAvailableException($"Bus with the id {bus.BusId} is not available!");
        }

        public bool UpdateDepartureTimeByBusId(int id, DateTime updatedTime)
        {
            var bus = GetBusById(id);
            bus.DepartureTime = updatedTime;
            if (UpdateBusByObject(bus) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePredictedTimeOfReachingDestinationById(int id, DateTime updatedTime)
        {
            var bus = GetBusById(id);
            bus.PredictedTimeOfReachingDestination = updatedTime;
            if (UpdateBusByObject(bus) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTotalNoOfSeatsById(int id, int totalNoOfSeats)
        {
            var bus = GetBusById(id);
            bus.TotalNoOfSeats = totalNoOfSeats;
            if (UpdateBusByObject(bus) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
