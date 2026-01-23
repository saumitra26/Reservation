using RoomReservation.Domain.Entities.Enum;

namespace RoomReservation.Domain.Entities;

public class UserModel
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public UserRole Role { get; set; } = UserRole.Client;
    public required string HashPassword { get; set; }
}