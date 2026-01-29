using System.Security.Authentication;
using RoomReservation.Identity.Application.Interface;
using RoomReservation.Identity.Application.Models;
using RoomReservation.Identity.Domain.Entities;
using RoomReservation.Identity.Domain.Entities.Enum;
namespace RoomReservation.Identity.Application.Service;

public class AuthService:IAuthService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAuthRepository _authRepository;
    private readonly IJwtGenerateToken _generateToken;
    public AuthService (IPasswordHasher passwordHasher, IAuthRepository authRepository, IJwtGenerateToken jwtGenerateToken)
    {
        _passwordHasher = passwordHasher;
        _authRepository = authRepository;
        _generateToken = jwtGenerateToken;
    }

    public  async Task AddUserAsync(RegisterUserCommand userCommand)
    {
        var hashPassword = _passwordHasher.Hash(userCommand.Password);
        var user = new AuthUser
        {
            UserName = userCommand.UserName,
            Email = userCommand.Email,
            PasswordHash = hashPassword,
            Role = UserRole.Client   
        };
        await _authRepository.AddUserAsync(user);
    }

    public async Task<string?> LoginAsync(AuthCredentials credentials)
    {
        var user = await _authRepository.GetByEmailAsync(credentials.Email);

        if (user == null)
            return null;

        var isValidPassword = _passwordHasher.Verify(
            user.PasswordHash,
            credentials.Password
           
        );

        if (!isValidPassword)
            throw new AuthenticationException("Invalid email or password.");

        return _generateToken.GenerateToken(user);
    }
    
}