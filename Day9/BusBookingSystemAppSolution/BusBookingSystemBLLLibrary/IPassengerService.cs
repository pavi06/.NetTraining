using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemBLLLibrary
{
    public interface IPassengerService
    {
        int AddPassenger(Passenger passenger);
        Passenger GetPassengerById(int id);
        List<Booking> GetAllBookingsByPassengerId(int id);
        List<Transaction> GetAllTransactionsByPassengerId(int id);
        List<Booking> GetAllBookingsWithStatusByPassengerId(int id, string bookingStatus);
        List<Transaction> GetAllTransactionsWithStatusByPassengerId(int id, string transactionStatus);
        Passenger DeletePassengerById(int id);
        Passenger UpdatePassengerByObject(Passenger passenger);
        bool UpdatePassengerNameById(int id);
        bool UpdatePassengerPhoneNumberById(int id);
        bool UpdatePassengerAddressById(int id);
        bool UpdatePassengerAgeById(int id);
    }
}
