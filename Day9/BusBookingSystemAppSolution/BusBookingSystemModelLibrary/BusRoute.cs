using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemModelLibrary
{
    public class BusRoute
    {
        public readonly List<Bus> _buses;
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteSourcePoint { get; set; } = string.Empty;
        public string RouteDestinationPoint { get; set; } = string.Empty;

        public BusRoute()
        {
            _buses = new List<Bus>();
        }
        public BusRoute(List<Bus> buses, int routeId, string routeName, string routeSourcePoint, string routeDestinationPoint)
        {
            this._buses = buses;
            RouteId = routeId;
            RouteName = routeName;
            RouteSourcePoint = routeSourcePoint;
            RouteDestinationPoint = routeDestinationPoint;
        }

        public override string ToString()
        {
            return $"-----------------Route Details------------\nRoute Id : {RouteId}\nRouteName : {RouteName}\nRouteSourcePoint : {RouteSourcePoint}\nRouteDestinationPoint : {RouteDestinationPoint}\nBuses Available: " +
                $"\n {_buses}";
        }

        public override bool Equals(object? obj)
        {
            BusRoute r1, r2;
            r1 = this;
            r2 = obj as BusRoute;
            return r1.RouteId.Equals(r2.RouteId);
        }
    }
}
