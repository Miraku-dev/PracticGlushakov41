namespace HotelBookingSystem
{
    public class RoomModel
    {
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = "Свободен";
    }
}