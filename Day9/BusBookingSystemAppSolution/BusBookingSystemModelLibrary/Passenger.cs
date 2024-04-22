using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusBookingSystemModelLibrary
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public List<Booking> BookingList { get; set; }
        public List<Transaction> TransctionMade { get; set; }

        public Passenger()
        {
            BookingList = new List<Booking>();
            TransctionMade = new List<Transaction>();
        }

        public Passenger(int id, string name, string phoneNumber,int age, string address, List<Booking> bookingList, List<Transaction> transctionMade)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Age = age;
            Address = address;
            BookingList = bookingList;
            TransctionMade = transctionMade;
        }

        public override string ToString()
        {
            return $"----------Passenger details-----------\nPasengerId : {Id}\nPassenger Name : {Name}\nPassenger PhoneNumber : {PhoneNumber}\nPassenger Age : {Age}\nPassenger Address : {Address}";
        }
    }
}
