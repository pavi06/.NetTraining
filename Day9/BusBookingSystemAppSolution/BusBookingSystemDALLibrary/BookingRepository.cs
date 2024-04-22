using BusBookingSystemModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystemDALLibrary
{
    public class BookingRepository : IRepository<int, Booking>
    {
        public readonly Dictionary<int, Booking> _bookings;

        public BookingRepository()
        {
            _bookings = new Dictionary<int, Booking>();
        }

        int GenerateId()
        {
            if (_bookings.Count == 0)
                return 1;
            int id = _bookings.Keys.Max();
            return ++id;
        }
        public Booking Add(Booking item)
        {
            if (_bookings.ContainsValue(item))
            {
                return null;
            }
            item.BookingId = GenerateId();
            _bookings.Add(item.BookingId, item);
            return item;
        }

        public Booking Delete(int key)
        {
            if (_bookings.ContainsKey(key))
            {
                var book = _bookings[key];
                _bookings.Remove(key);
                return book;
            }
            return null;
        }

        public Booking Get(int key)
        {
            return _bookings.ContainsKey(key) ? _bookings[key] : null;
        }

        public List<Booking> GetAll()
        {
            if (_bookings.Count == 0)
                return null;
            return _bookings.Values.ToList();
        }

        public Booking Update(Booking item)
        {
            if (_bookings.ContainsKey(item.BookingId))
            {
                _bookings[item.BookingId] = item;
                return item;
            }
            return null;
        }
    }
}
