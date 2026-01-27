using RoomReservation.Identity.Domain.Entities.Enum;

namespace RoomReservation.Identity.Domain.Entities;

public class AuthUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public UserRole Role { get; set; }
    public required string PasswordHash { get; set; }
}