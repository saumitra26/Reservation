using RoomReservation.Infrastructure.Data;
using RoomReservation.Application.Repositories;
using RoomReservation.Domain.Entities;

namespace RoomReservation.Infrastructure.Repositories;

public class RoomRepository:IRoomRepository
{
    private readonly ApplicationDbContext _context;
    public RoomRepository (ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Room> AddAsync(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room;
    }
    public async Task<Room?> GetByIdAsync(int id)
    {
        return await _context.Rooms.FindAsync(id);
    }
}

