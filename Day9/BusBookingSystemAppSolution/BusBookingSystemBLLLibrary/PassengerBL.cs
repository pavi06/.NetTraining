using BusBookingSystemBLLLibrary.CustomExceptions;
using BusBookingSystemDALLibrary;
using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary
{
    public class PassengerBL : IPassengerService
    {
        readonly IRepository<int, Passenger> _passengerRepository;
        public PassengerBL()
        {
            _passengerRepository = new PassengerRepository();
        }
        public int AddPassenger(Passenger passenger)
        {
            var passengerAdded = _passengerRepository.Add(passenger);
            if (passengerAdded != null)
            {
                return passengerAdded.Id;
            }
            throw new ObjectAlreadyExistsException("Current Passenger Already Exists!");
        }

        public Passenger DeletePassengerById(int id)
        {
            var passenger = _passengerRepository.Get(id);
            if (passenger != null)
            {
                return passenger;
            }
            throw new ObjectNotAvailableException($"Passenger with the id {id} is not available!");
        }

        public Passenger GetPassengerById(int id)
        {
            var passenger = _passengerRepository.Get(id);
            if (passenger != null)
            {
                return passenger;
            }
            throw new ObjectNotAvailableException($"Passenger with the id {id} is not available!");
        }

        public List<Booking> GetAllBookingsByPassengerId(int id)
        {
            var bookings = GetPassengerById(id).BookingList;
            if (bookings != null) {
                return bookings;
            }
            throw new NoBookingsAvailableException($"for the passenger with id - {id}");
        }

        public List<TransactionForBooking> GetAllTransactionsByPassengerId(int id)
        {
            var transactionList = GetPassengerById(id).TransctionMade;
            if(transactionList != null)
            {
                return transactionList;
            }
            throw new NoTransactionAvailableException($"with the passenger id - {id}");
        }

        public List<Booking> GetAllBookingsWithStatusByPassengerId(int id, string bookingStatus)
        {
            var bookingList = GetAllBookingsByPassengerId(id);
            foreach (var booking in bookingList)
            {
                if (booking.BookingStatus != bookingStatus) { 
                    bookingList.Remove(booking);
                }
            }
            if(bookingList.Count>0)
            {
                return bookingList;
            }
            throw new NoBookingsAvailableException($"for the passenger with id - {id} and status - {bookingStatus}");
        }

        public List<TransactionForBooking> GetAllTransactionsWithStatusByPassengerId(int id, string transactionStatus)
        {
            var bookingList = GetAllTransactionsByPassengerId(id);
            foreach (var booking in bookingList)
            {
                if (booking.TransactionStatus != transactionStatus)
                {
                    bookingList.Remove(booking);
                }
            }
            if (bookingList.Count > 0)
            {
                return bookingList;
            }
            throw new NoTransactionAvailableException($"for the passenger with id - {id} and status - {transactionStatus}");
        }

        public Passenger UpdatePassengerByObject(Passenger passenger)
        {
            var updatedPassenger = _passengerRepository.Update(passenger);
            if (updatedPassenger != null) {
                return updatedPassenger;
            }
            throw new ObjectNotAvailableException($"Passenger with the id {passenger.Id} is not available!");
        }

        public bool UpdatePassengerAddressById(int id, string address)
        {
            var passenger = GetPassengerById(id);
            passenger.Address = address;
            if (UpdatePassengerByObject(passenger) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePassengerAgeById(int id, int age)
        {
            var passenger = GetPassengerById(id);
            passenger.Age = age;
            if (UpdatePassengerByObject(passenger) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePassengerNameById(int id, string name)
        {
            var passenger = GetPassengerById(id);
            passenger.Name = name;
            if (UpdatePassengerByObject(passenger) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePassengerPhoneNumberById(int id, string phoneNumber)
        {
            var passenger = GetPassengerById(id);
            passenger.PhoneNumber = phoneNumber;
            if (UpdatePassengerByObject(passenger) != null)
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
