namespace RoomReservation.Application.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(string userName, string userRome, string password);
    Task<string?> LoginAsync(string email, string password);
}