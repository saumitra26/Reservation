using RoomReservation.Identity.Application.Models;

namespace RoomReservation.Identity.Application.Interface;

public interface IAuthService
{
    Task AddUserAsync(RegisterUserCommand userCommand);
    Task<string> LoginAsync(AuthCredentials credentials);
}