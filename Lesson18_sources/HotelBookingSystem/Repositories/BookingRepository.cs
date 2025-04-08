using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Repositories;

public class BookingRepository : IRepository<Booking>
{
    private readonly HotelDbContext _context;

    public BookingRepository(HotelDbContext context) => _context = context;

    public async Task<IEnumerable<Booking>> GetAllAsync() 
        => await _context.Bookings.Include(b => b.Room).ToListAsync();

    public async Task<Booking> GetByIdAsync(int id) 
        => await _context.Bookings.Include(b => b.Room).FirstOrDefaultAsync(b => b.Id == id);

    public async Task AddAsync(Booking booking) 
        => await _context.Bookings.AddAsync(booking);

    public async Task UpdateAsync(Booking booking) 
        => _context.Bookings.Update(booking);

    public async Task DeleteAsync(Booking booking) 
        => _context.Bookings.Remove(booking);

    public async Task SaveAsync() 
        => await _context.SaveChangesAsync();
}