using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary
{
    public interface IBookingService
    {
        int AddBooking(Booking booking);
        Booking GetBookingById(int id);
        List<Booking> GetAllBookings();
        Booking DeleteBookingById(int id);
        Booking UpdateBookingByObject(Booking booking);
        Passenger GetPassengerByBookingId(int id);
        Bus GetBusByBookingId(int id);
        Transaction GetTransactionByBookingId(int id);
        string GetBookingStatusById(int id);
        bool UpdateBookingStatusById(int id);
        bool UpdateNoOfSeatsToBookById(int id);
        bool UpdateBookingDateById(int id, DateTime dateTime);
    }
}
