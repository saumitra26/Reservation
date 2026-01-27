using RoomReservation.Identity.Domain.Entities.Enum;

namespace RoomReservation.Identity.Application.Models;

public class RegisterUserCommand
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}