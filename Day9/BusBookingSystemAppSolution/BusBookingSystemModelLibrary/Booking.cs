using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusBookingSystemModelLibrary
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Passenger Passenger { get; set; }
        public Bus Bus { get; set; }
        public DateTime BookingDate { get; set; }
        public int NoOfSeatsToBook { get; set; }
        public string BookingStatus { get; set; }
        public Transaction Transaction { get; set; }

        public Booking(int id, Passenger passenger, Bus bus, DateTime bookingDate, int noOfSeatsBooked, string bookingStatus, Transaction transaction)
        {
            BookingId = id;
            Passenger = passenger;
            Bus = bus;
            BookingDate = bookingDate;
            NoOfSeatsToBook = noOfSeatsBooked;
            BookingStatus = bookingStatus;
            Transaction = transaction;
        }

        public override string ToString()
        {
            return $"----------Booking details-----------\nBookingId : {BookingId}\nPassenger Booked : {Passenger.Name}\nBooking Date : {BookingDate}\nBus Booked : {Bus.BusId}\nNo.Of Seats Booked : {NoOfSeatsToBook}\nPayment status : {Transaction.TransactionStatus}";
        }
        public override bool Equals(object? obj)
        {
            Booking b1, b2;
            b1 = this;
            b2 = obj as Booking;
            return b1.BookingId.Equals(b2.BookingId);
        }
    }
}
