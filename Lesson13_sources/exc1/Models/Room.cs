using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public decimal PricePerNight { get; set; }

        public string NumberWithType => $"{Number} ({Type})";

        public bool IsAvailable(DateTime checkIn, DateTime checkOut, IEnumerable<Booking> bookings)
        {
            return !bookings.Any(b =>
                b.RoomNumber == Number &&
                !(checkOut <= b.CheckInDate || checkIn >= b.CheckOutDate));
        }
    }
}