namespace HotelBookingSystem.Models;

public class Room
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Type { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; } = true;
    public ICollection<Booking> Bookings { get; set; }
}