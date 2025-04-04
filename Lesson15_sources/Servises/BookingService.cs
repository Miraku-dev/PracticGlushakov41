using HotelBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem.Services
{
    public class BookingService
    {
        public List<Booking> _bookings = new List<Booking>();

        public async Task BookRoomAsync(Booking booking)
        {
            await Task.Delay(3000); // Имитация задержки

            if (booking.Id == 0)
            {
                booking.Id = _bookings.Count + 1;
                _bookings.Add(booking);
            }
            else
            {
                var existing = _bookings.FirstOrDefault(b => b.Id == booking.Id);
                if (existing != null)
                {
                    _bookings.Remove(existing);
                    _bookings.Add(booking);
                }
            }
        }

        public IEnumerable<Booking> GetBookings() => _bookings;

        public void DeleteBooking(int id)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);
            if (booking != null)
            {
                _bookings.Remove(booking);
            }
        }
    }
}