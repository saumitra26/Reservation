using Microsoft.EntityFrameworkCore;
using RoomReservation.Application.Repositories;
using RoomReservation.Domain.Entities;
using RoomReservation.Infrastructure.Data;

namespace RoomReservation.Infrastructure.Repositories;

public class ReservationRepository:IReservationRepository
{
    private  readonly ApplicationDbContext _context;
    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
  
    public async Task<bool> HasOverlappingReservations(
        int roomId,
        DateTime startTime,
        DateTime endTime)
    {
        return await _context.Reservations.AnyAsync(r =>
            r.RoomId == roomId &&
            startTime < r.EndTime &&
            endTime > r.StartTime
        );
    }

    public async Task<Reservation> AddAsync(Reservation reservation)
    {
       _context.Reservations.Add(reservation);
         await _context.SaveChangesAsync();
        return reservation;
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }

    public async Task<Reservation> UpdateAsync(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();
        return reservation;
    }

    public async Task DeleteAsync(int id)
    {
         _context.Remove(id);
         await _context.SaveChangesAsync();
    }
}