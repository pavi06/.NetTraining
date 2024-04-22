using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary
{
    public interface IBusRouteService
    {
        int AddBusRoute(BusRoute busRoute);
        BusRoute GetBusRouteById(int id);
        List<BusRoute> GetAllBusRoute();
        BusRoute DeleteBusRouteById(int id);
        BusRoute UpdateBusRouteByObject(BusRoute busRoute);
        List<Bus> GetAllBusWithBusRouteId(int id);
        bool UpdateBusRouteNameById(int id, string routeName);
        bool UpdateBusRouteSourcePointById(int id, string source);
        bool UpdateBusRouteDestinationPointById(int id, string destination);
        string GetBusRouteDestinationPointById(int id);
        string GetBusRouteSourcePointById(int id);
    }
}
