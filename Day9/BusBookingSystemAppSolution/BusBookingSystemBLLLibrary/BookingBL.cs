using BusBookingSystemBLLLibrary.CustomExceptions;
using BusBookingSystemDALLibrary;
using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary
{
    public class BookingBL : IBookingService
    {
        readonly IRepository<int, Booking> _bookingRepository;
        public BookingBL()
        {
            _bookingRepository = new BookingRepository();
        }
        public int AddBooking(Booking booking)
        {
            var bookTicked = _bookingRepository.Add(booking);
            if (bookTicked != null)
            {
                return bookTicked.BookingId;
            }
            throw new ObjectAlreadyExistsException($"Booking with id {booking.BookingId} Already Exists!");
        }

        public Booking DeleteBookingById(int id)
        {
            var bookTicket = _bookingRepository.Get(id);
            if (bookTicket != null)
            {
                return bookTicket;
            }
            throw new ObjectNotAvailableException($"Booking with the id {id} is not available!");
        }

        public List<Booking> GetAllBookings()
        {
            var bookingsDone = _bookingRepository.GetAll();
            if (bookingsDone != null)
            {
                return bookingsDone;
            }
            throw new NoBookingsAvailableException("");
        }

        public Booking GetBookingById(int id)
        {
            var bookTicket = _bookingRepository.Get(id);
            if (bookTicket != null)
            {
                return bookTicket;
            }
            throw new ObjectNotAvailableException($"Booking with the id {id} is not available!");
        }

        public string GetBookingStatusById(int id)
        {
            string bookingStatus = GetBookingById(id).BookingStatus;
            if (bookingStatus != null) { 
                return bookingStatus;
            }
            throw new NullValueException("");
        }

        public Bus GetBusByBookingId(int id)
        {
            var bus = GetBookingById(id).Bus;
            if(bus != null)
            {
                return bus;
            }
            throw new ObjectNotAvailableException($"Bus associated with the booking id - {id} is not available");
        }

        public Passenger GetPassengerByBookingId(int id)
        {
            var passenger = GetBookingById(id).Passenger;
            if (passenger != null)
            {
                return passenger;
            }
            throw new ObjectNotAvailableException($"Passenger associated with the booking id - {id} is not available");
        }

        public Transaction GetTransactionByBookingId(int id)
        {
            var transaction = GetBookingById(id).Transaction;
            if (transaction != null)
            {
                return transaction;
            }
            throw new ObjectNotAvailableException($"Transaction associated with the booking id - {id} is not available");
        }

        public Booking UpdateBookingByObject(Booking booking)
        {
            var updatedBooking = _bookingRepository.Update(booking);
            if(updatedBooking != null)
            {
                return updatedBooking;
            }
            throw new ObjectNotAvailableException($"Booking with the id {booking.BookingId} is not available!");
        }

        public bool UpdateBookingDateById(int id, DateTime dateTime)
        {
            var bookTicket = GetBookingById(id);
            bookTicket.BookingDate = dateTime;
            if (UpdateBookingByObject(bookTicket) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateBookingStatusById(int id, string status)
        {
            var bookTicket = GetBookingById(id);
            bookTicket.BookingStatus = status;
            if (UpdateBookingByObject(bookTicket) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateNoOfSeatsToBookById(int id, int seats)
        {
            var bookTicket = GetBookingById(id);
            bookTicket.NoOfSeatsToBook = seats;
            if (UpdateBookingByObject(bookTicket) != null)
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
