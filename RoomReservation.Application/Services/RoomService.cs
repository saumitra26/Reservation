using RoomReservation.Application.Interfaces;
using RoomReservation.Application.Repositories;
using RoomReservation.Domain.Entities;
using RoomReservation.Domain.Entities.Enum;


namespace RoomReservation.Application.Services;

public class RoomService:IRoomService
{
   private readonly IRoomRepository _roomRepository;

   public RoomService(IRoomRepository roomRepository)
   {
       _roomRepository = roomRepository;
   }
    public async Task<Room> CreateAsync(Room request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("Room name is required.");
        var room = new Room
        {
            Name = request.Name.Trim(),
            Description = request.Description.Trim(),
            Status = RoomStatus.Available
        };


        return await _roomRepository.AddAsync(room);


    }

    public async Task<Room?> GetByIdAsync(int id)
    {
        var room = await _roomRepository.GetByIdAsync(id);

        if (room == null)
            throw new ArgumentException("Room not found");

        return room;
    }
}