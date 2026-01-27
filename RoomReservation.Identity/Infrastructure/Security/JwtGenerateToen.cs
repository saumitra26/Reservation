using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RoomReservation.Identity.Application.Interface;
using RoomReservation.Identity.Domain.Entities;

namespace RoomReservation.Identity.Infrastructure.Security;

public class JwtGenerateToken:IJwtGenerateToken

{
    private readonly IConfiguration _configuration;
    public JwtGenerateToken(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(AuthUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(

            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            signingCredentials: credentials,
            notBefore: DateTime.UtcNow, 
            expires: DateTime.UtcNow.AddMinutes(60)

        );
        return new JwtSecurityTokenHandler().WriteToken(token);
        
    }
}