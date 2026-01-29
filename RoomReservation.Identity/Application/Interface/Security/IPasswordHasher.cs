namespace RoomReservation.Identity.Application.Interface;

public interface IPasswordHasher
{
     string Hash(string password);
     bool Verify(string hashPassword, string password);

}