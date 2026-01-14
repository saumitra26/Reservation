using RoomReservation.Data;
using RoomReservation.Models.Dtos.Request.Reservations;
using RoomReservation.Models.Dtos.Request.Rooms;
using RoomReservation.Models.Dtos.Responses.Rooms;
using RoomReservation.Models.Entities;
using RoomReservation.Models.Enums;
using RoomReservation.Services.Interfaces;


namespace RoomReservation.Services.Implementations;

public class RoomService:IRoomService
{
    private readonly ApplicationDbContext _context;
    public RoomService (ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<RoomResponse> CreateAsync(CreateRoomRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("Room name is required.");
        var room = new Room
        {
            Name = request.Name.Trim(),
            Description = request.Description.Trim(),
            Status = RoomStatus.Available
        };

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();

        return new RoomResponse
        {
            Id = room.Id,
            Name = room.Name,
            Description = room.Description,
            Status = room.Status
        };
    }

}