using Microsoft.EntityFrameworkCore;
using RoomReservation.Identity.Application;
using RoomReservation.Identity.Domain.Entities;
using RoomReservation.Identity.Infrastructure.Data;

namespace RoomReservation.Identity.Infrastructure.Repositories;

public class AuthRepository:IAuthRepository
{
    private readonly IdentityDbContext _context;

    public AuthRepository(IdentityDbContext context)
    {
        _context = context;
    }
    public async Task AddUserAsync(AuthUser user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

    }

    public async Task<AuthUser> GetByEmailAsync(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(u=>u.Email==email);
        
    }
}