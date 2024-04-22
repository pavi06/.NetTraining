namespace BusBookingSystemModelLibrary
{
    public class Bus
    {
        public int BusId { get; set; }
        public BusRoute BusRoute { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime PredictedTimeOfReachingDestination { get; set; }
        public int TotalNoOfSeats { get; set; }
        public int NoOfSeatsAvailable { get; set; }
        public List<Passenger> Passenger { get; set; }

        public Bus()
        {
            Passenger = new List<Passenger>();
        }

        public Bus(int busId, BusRoute busRoute, DateTime departureTime, DateTime predictedTimeOfReachingDestination, int totalNoOfSeats, int noOfSeatsAvailable, List<Passenger> passenger)
        {
            BusId = busId;
            BusRoute = busRoute;
            DepartureTime = departureTime;
            PredictedTimeOfReachingDestination = predictedTimeOfReachingDestination;
            TotalNoOfSeats = totalNoOfSeats;
            NoOfSeatsAvailable = noOfSeatsAvailable;
            Passenger = passenger;
        }

        public override string ToString()
        {
            return $"-----------Bus Details----------\nBus Id : {BusId}\nBus Route : {BusRoute.RouteName}\nDeparture Time : {DepartureTime}\nNo.Of Seats Booked : {TotalNoOfSeats - NoOfSeatsAvailable}";
        }

    }
}
