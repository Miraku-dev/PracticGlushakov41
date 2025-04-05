using System;

namespace HotelBookingSystem
{
    public class BookingModel
    {
        public string FullName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int RoomNumber { get; set; }
    }
}