using BusBookingSystemModelLibrary;
using BusBookingSystemBLLLibrary;
using BusBookingSystemBLLLibrary.CustomExceptions;
using System.Numerics;

namespace BusBookingSystemApp
{
    internal class Program
    {
        public void BuildBusFromConsole(Bus bus)
        {
            Console.WriteLine("Please Enter the Bus Details for Creating the Bus\n");

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
        static void Main(string[] args)
        {
            Program program = new Program();
            BusBL busBl = new BusBL();
            List<int> busIds = new List<int>();
            busIds.Add(program.AddBus(busBl));
           
        }
    }
}
