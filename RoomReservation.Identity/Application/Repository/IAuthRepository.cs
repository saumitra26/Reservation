using RoomReservation.Identity.Domain.Entities;

namespace RoomReservation.Identity.Application;

public interface IAuthRepository
{
    Task AddUserAsync(AuthUser user);
    Task<AuthUser> GetByEmailAsync(string email);
}