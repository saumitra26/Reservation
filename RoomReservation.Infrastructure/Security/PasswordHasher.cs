using Microsoft.AspNetCore.Identity;
using RoomReservation.Application.Interfaces.Security;

namespace RoomReservation.Infrastructure.Security;

public class PasswordHasher:IPasswordHasher
{
    private readonly PasswordHasher<object> _hasher = new();
    public string Hash(string password)
    {
        return _hasher.HashPassword(null!,password);
        
    }

    public bool Verify(string password, string hashPassword)
    {
        var result= _hasher.VerifyHashedPassword(null!, hashPassword, password);
        return (result == PasswordVerificationResult.Success) ||
               (result == PasswordVerificationResult.SuccessRehashNeeded);
    }
}