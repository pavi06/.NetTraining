using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary
{
    public interface IBusService
    {
        int AddBus(Bus bus);
        Bus GetBusById(int id);
        List<Bus> GetAllBus();
        List<Bus> GetAllBusByDepartureTime(DateTime time);
        Bus DeleteBusById(int id);
        Bus UpdateBusByObject(Bus bus);
        BusRoute GetBusRouteByBusId(int id);
        List<Passenger> GetAllPassengersByBusId(int id);
        int GetNoOfSeatsAvailableForBusById(int id);
        int GetNoOfSeatsBookedForBusById(int id);
        bool UpdatePredictedTimeOfReachingDestinationById(int id, DateTime updatedTime);
        bool UpdateTotalNoOfSeatsById(int id, int totalNoOfSeats);
        bool UpdateDepartureTimeByBusId(int id, DateTime updatedTime);
    }
}
