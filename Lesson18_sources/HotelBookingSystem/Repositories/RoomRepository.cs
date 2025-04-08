using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Repositories;

public class RoomRepository : IRepository<Room>
{
    private readonly HotelDbContext _context;

    public RoomRepository(HotelDbContext context) => _context = context;

    public async Task<IEnumerable<Room>> GetAllAsync() 
        => await _context.Rooms.ToListAsync();

    public async Task<Room> GetByIdAsync(int id) 
        => await _context.Rooms.FindAsync(id);

    public async Task AddAsync(Room room) 
        => await _context.Rooms.AddAsync(room);

    public async Task UpdateAsync(Room room) 
        => _context.Rooms.Update(room);

    public async Task DeleteAsync(Room room) 
        => _context.Rooms.Remove(room);

    public async Task SaveAsync() 
        => await _context.SaveChangesAsync();
}