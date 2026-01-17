using RoomReservation.Domain.Entities;

namespace RoomReservation.Application.Repositories;

public interface IRoomRepository
{
    Task<Room> AddAsync(Room room);
    Task<Room?> GetByIdAsync(int id);
}