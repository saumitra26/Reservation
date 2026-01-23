using RoomReservation.Domain.Entities;

namespace RoomReservation.Application.Interfaces.Security;

public interface IJwtTokenGenerator
{
     string GenerateToken(UserModel user);
}