using RoomReservation.Application.Interfaces;
using RoomReservation.Application.Interfaces.Security;
using RoomReservation.Application.Repositories;
using RoomReservation.Domain.Entities;
using RoomReservation.Domain.Entities.Enum;

namespace RoomReservation.Application.Services;

public class AuthService:IAuthService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAuthRepository _authRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthService (IPasswordHasher passwordHasher, IAuthRepository authRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _passwordHasher = passwordHasher;
        _authRepository = authRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
        
    public async Task RegisterAsync(string userName, string email, string password)
    {
       var hashPassword= _passwordHasher.Hash(password);
       var user = new UserModel
       {
           UserName = userName,
           Email = email,
           HashPassword = hashPassword,
           Role = UserRole.Client
       };
       await _authRepository.AddAsync(user);
    }

    public async Task<string?> LoginAsync(string email, string password)
    {
      var user = await _authRepository.GetUserAsync(email);
    if (user == null)
        return null;
    var isValidPassword = _passwordHasher.Verify(
        password,
        user.HashPassword
    );
    if (!isValidPassword)
        return null;
    
    return _jwtTokenGenerator.GenerateToken(user);
    }
}

