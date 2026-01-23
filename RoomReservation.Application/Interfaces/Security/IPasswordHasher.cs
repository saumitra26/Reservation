namespace RoomReservation.Application.Interfaces.Security;

public interface IPasswordHasher
{
  string Hash(string password);
  bool Verify(string password, string hashPassword);
}