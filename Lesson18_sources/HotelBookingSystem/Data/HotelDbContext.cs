namespace HotelBookingSystem.Data;

using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Models;

public class HotelDbContext(DbContextOptions<HotelDbContext> options) : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=hotel.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Инициализация тестовыми данными
        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, Number = "101", Type = "Standard", PricePerNight = 100 },
            new Room { Id = 2, Number = "102", Type = "Standard", PricePerNight = 100 },
            new Room { Id = 3, Number = "201", Type = "Deluxe", PricePerNight = 150 },
            new Room { Id = 4, Number = "202", Type = "Deluxe", PricePerNight = 150 },
            new Room { Id = 5, Number = "301", Type = "Suite", PricePerNight = 250 }
        );
    }
}