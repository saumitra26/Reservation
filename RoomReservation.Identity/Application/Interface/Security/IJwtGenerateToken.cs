using RoomReservation.Identity.Domain.Entities;

namespace RoomReservation.Identity.Application.Interface;

public interface IJwtGenerateToken
{
      string GenerateToken(AuthUser user);
}