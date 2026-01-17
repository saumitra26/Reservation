

using RoomReservation.Domain.Entities;
using RoomReservation.Domain.Entities.Enum;

namespace RoomReservation.Application.Interfaces;

public interface IRoomService
{
   Task<Room> CreateAsync(Room room);
   Task<Room?> GetByIdAsync(int id);
}