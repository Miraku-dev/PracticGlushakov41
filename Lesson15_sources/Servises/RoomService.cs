using HotelBookingSystem.Models;
using System.Collections.Generic;

namespace HotelBookingSystem.Services
{
    public class RoomService
    {
        public IEnumerable<Room> GetRooms()
        {
            var rooms = new List<Room>();
            for (int i = 1; i <= 10; i++)
            {
                rooms.Add(new Room
                {
                    Number = i,
                    Type = i % 2 == 0 ? "Standard" : "Deluxe",
                    PricePerNight = i % 2 == 0 ? 100 : 150
                });
            }
            return rooms;
        }
    }
}