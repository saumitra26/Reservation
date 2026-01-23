using RoomReservation.Domain.Entities;

namespace RoomReservation.Application.Repositories;

public interface IAuthRepository
{
    Task AddAsync(UserModel user);
    Task<UserModel?> GetUserAsync(string email);
}