using Microsoft.EntityFrameworkCore;
using RoomReservation.Application.Repositories;
using RoomReservation.Domain.Entities;
using RoomReservation.Infrastructure.Data;

namespace RoomReservation.Infrastructure.Repositories;

public class AuthRepository:IAuthRepository
{
    public readonly ApplicationDbContext _context;

    public AuthRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserModel user)
    {
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    

    public async Task<UserModel> GetUserAsync(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(e=>e.Email==email);
    }
}