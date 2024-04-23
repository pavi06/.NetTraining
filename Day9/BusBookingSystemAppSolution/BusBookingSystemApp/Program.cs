using BusBookingSystemModelLibrary;
using BusBookingSystemBLLLibrary;
using BusBookingSystemBLLLibrary.CustomExceptions;
using System.Numerics;
using System.Transactions;
using System.Runtime.InteropServices;
using System;

namespace BusBookingSystemApp
{
    internal class Program
    {
        public void BuildBusFromConsole(Bus bus)
        {
            Console.WriteLine("Please Enter the Bus Details for Creating the Bus\nEnter the Bus Route Id : ");

            Console.WriteLine("Enter the Bus departure Time : ");
            bus.DepartureTime=Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the predicted time of reaching the destination : ");
            bus.PredictedTimeOfReachingDestination = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter total number of seats : ");
            int totalNoOfSeats;
            while (!int.TryParse(Console.ReadLine(), out totalNoOfSeats)) {
                Console.WriteLine("Please Enter the valid Input. It should be in digit!");
            }
            bus.TotalNoOfSeats = totalNoOfSeats;

            Console.WriteLine("Enter total number of seats available : ");
            int totalNoOfSeatsAvailable;
            while (!int.TryParse(Console.ReadLine(), out totalNoOfSeatsAvailable))
            {
                Console.WriteLine("Please Enter the valid Input. It should be in digit!");
            }
            bus.NoOfSeatsAvailable = totalNoOfSeatsAvailable;
        }

        public void BuildPassengerFromConsole(Passenger passenger) {
            Console.WriteLine("Please Enter the Passenger Details for Creating the Passenger");
            do
            {
                Console.WriteLine("Enter the Passenger Name:");
                passenger.Name = Console.ReadLine();
            } while (passenger.Name.Any(char.IsDigit) || passenger.Name == "");
            Console.WriteLine("Enter the passenger Phone number : ");
            passenger.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter the Passenger Age:");
            passenger.Age= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Passenger Address : ");
            passenger.Address = Console.ReadLine();
        }

        public void BuildBusRouteFromConsole(BusRoute busRoute)
        {
            Console.WriteLine("Please Enter the Bus Route Details for Creating the BusRoute");
            do{
                Console.WriteLine("Enter the bus Route Name:");
                busRoute.RouteName = Console.ReadLine();
            } while (busRoute.RouteName.Any(char.IsDigit) || busRoute.RouteName == "");

            do
            {
                Console.WriteLine("Enter the bus Route source point:");
                busRoute.RouteSourcePoint = Console.ReadLine();
            } while (busRoute.RouteSourcePoint.Any(char.IsDigit) || busRoute.RouteSourcePoint == "");

            do
            {
                Console.WriteLine("Enter the bus Route Destination point:");
                busRoute.RouteDestinationPoint = Console.ReadLine();
            } while (busRoute.RouteDestinationPoint.Any(char.IsDigit) || busRoute.RouteDestinationPoint == "");

        }

        public int AddBus(BusBL busBL)
        {
            try
            {
                Bus bus = new Bus();
                BuildBusFromConsole(bus);
                int busId = busBL.AddBus(bus);
                Console.WriteLine("Bus is created successfully!!");
                Console.WriteLine("--------------------------------\n");
                Bus retrivedbus = busBL.GetBusById(busId);
                Console.WriteLine(retrivedbus.ToString());
                return busId;
            }
            catch (ObjectAlreadyExistsException oaee)
            {
                Console.WriteLine(oaee.Message);
            }
            return -1;
        }

        public int AddBusRoute(BusRouteBL busRouteBl)
        {

            try
            {
                BusRoute busRoute = new BusRoute();
                BuildBusRouteFromConsole(busRoute);
                int busRouteId = busRouteBl.AddBusRoute(busRoute);
                Console.WriteLine("BusRoute added successfully!!");
                Console.WriteLine("--------------------------------\n");
                BusRoute retrivedbusRoute = busRouteBl.GetBusRouteById(busRouteId);
                Console.WriteLine(retrivedbusRoute.ToString());
                return busRouteId;
            }
            catch (ObjectAlreadyExistsException oaee)
            {
                Console.WriteLine(oaee.Message);
            }
            return -1;
        }

        public int AddPassenger(PassengerBL passengerBL)
        {
            try
            {
                Passenger passenger = new Passenger();
                BuildPassengerFromConsole(passenger);
                int passengerId = passengerBL.AddPassenger(passenger);
                Console.WriteLine("Passenger added successfully!!");
                Console.WriteLine("--------------------------------\n");
                Passenger retrivedPassenger = passengerBL.GetPassengerById(passengerId);
                Console.WriteLine(retrivedPassenger.ToString());
                return passengerId;
            }
            catch (ObjectAlreadyExistsException oaee)
            {
                Console.WriteLine(oaee.Message);
            }
            return -1;
        }

        public static bool UpdateBus(int id, BusBL busBL)
        {
            try
            {
                Bus retrievedBus = busBL.GetBusById(id);
                Console.WriteLine("---------------------------");
                Console.WriteLine(retrievedBus.ToString());
               
            }
            catch (ObjectNotAvailableException onae)
            {
                Console.WriteLine(onae.Message);
            }
            return false;
        }

        public void PrintMenu( BusRouteBL busRouteBl, BusBL busBl, PassengerBL passengerBl)
        { 
            Console.WriteLine("Hello welcome...\n1.Book Ticket\n2.Check for Available Buses\n3.Check Booking");
            int val = Convert.ToInt32(Console.ReadLine());
            string userInput = string.Empty;
            switch (val) {
                case 1:
                    do
                    {                        
                        Console.WriteLine("Do you want to book tickets??\nPress Y/N");
                        userInput = Console.ReadLine();
                    } while (userInput.ToLower() != "y" && userInput.ToLower() != "n");

                    if (userInput.ToLower() == "n")
                    {
                        Console.WriteLine("------------Thank you------------");
                    }
                    else
                    {
                        addBooking(busBl,busRouteBl);
                    }
                    break;

                case 2:
                    break;

            }
            
            
        }

        public int addBooking(BusBL busBl, BusRouteBL busRouteBl)
        {
            try
            {
                Booking bookingTicket = new Booking();
                Console.WriteLine("Enter the details for booking\nEnter the Destination :");
                string destination = Console.ReadLine();
                Console.WriteLine("Available buses for the route: ");
                List<Bus> buses = busRouteBl.GetAllBusByDestination(destination);
                Console.WriteLine("Buses Available : ");
                foreach (Bus bus in buses)
                {
                    Console.WriteLine( bus.ToString());
                }
                Console.WriteLine("Enter the choosen bus id :");
                int id = Convert.ToInt32(Console.ReadLine());
                bookingTicket.Bus = busBl.GetBusById(id);
                Console.WriteLine("Enter the booking date :");
                bookingTicket.BookingDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine($"No. of seats available in bus : {bookingTicket.Bus.NoOfSeatsAvailable}");
                Console.WriteLine("Enter the number of seats to book :");
                bookingTicket.NoOfSeatsToBook = Convert.ToInt32(Console.ReadLine());        

            }
            catch (ObjectAlreadyExistsException oaee)
            {
                Console.WriteLine(oaee.Message);
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            //----------------Adding BusRoute
            BusRouteBL busRouteBl = new BusRouteBL();
            List<int> busRouteIds = new List<int>();
            busRouteIds.Add(program.AddBusRoute(busRouteBl));

            //----------------Adding Bus

            BusBL busBl = new BusBL();
            List<int> busIds = new List<int>();
            busIds.Add(program.AddBus(busBl));

            //--------------------------Passenger
            PassengerBL passengerBL = new PassengerBL();
            List<int> passengerIds = new List<int>();
            passengerIds.Add(program.AddPassenger(passengerBL));

            //-----------------------Menu For Passenger Booking
            program.PrintMenu(busRouteBl,busBl,passengerBL); 
            
            //---------
            

        }
    }
}
