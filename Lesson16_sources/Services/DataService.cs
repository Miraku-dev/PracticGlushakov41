using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace HotelBookingSystem.Services
{
    public class DataService
    {
        private const string RoomsFile = "rooms.json";
        private const string BookingsFile = "bookings.json";
        private const string UsersFile = "users.json";

        public List<RoomModel> LoadRooms()
        {
            if (!File.Exists(RoomsFile))
            {
                var defaultRooms = new List<RoomModel>
                {
                    new RoomModel { RoomNumber = 101, Price = 100m },
                    new RoomModel { RoomNumber = 102, Price = 120m }
                };
                SaveRooms(defaultRooms);
            }
            return JsonConvert.DeserializeObject<List<RoomModel>>(File.ReadAllText(RoomsFile));
        }

        public void SaveRooms(IEnumerable<RoomModel> rooms)
        {
            File.WriteAllText(RoomsFile, JsonConvert.SerializeObject(rooms, Formatting.Indented));
        }

        public void SaveBooking(BookingModel booking)
        {
            var bookings = File.Exists(BookingsFile)
                ? JsonConvert.DeserializeObject<List<BookingModel>>(File.ReadAllText(BookingsFile))
                : new List<BookingModel>();
            bookings.Add(booking);
            File.WriteAllText(BookingsFile, JsonConvert.SerializeObject(bookings, Formatting.Indented));
        }

        public UserModel AuthenticateUser(string username, string password)
        {
            if (!File.Exists(UsersFile)) return null;
            var users = JsonConvert.DeserializeObject<List<UserModel>>(File.ReadAllText(UsersFile));
            return users.Find(u => u.Username == username && u.Password == password);
        }

        public void RegisterUser(UserModel user)
        {
            var users = File.Exists(UsersFile)
                ? JsonConvert.DeserializeObject<List<UserModel>>(File.ReadAllText(UsersFile))
                : new List<UserModel>();
            if (users.Exists(u => u.Username == user.Username)) return;
            users.Add(user);
            File.WriteAllText(UsersFile, JsonConvert.SerializeObject(users, Formatting.Indented));
        }
    }
}