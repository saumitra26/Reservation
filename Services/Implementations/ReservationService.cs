using Microsoft.EntityFrameworkCore;
using RoomReservation.Data;
using RoomReservation.Models.Dtos.Request.Reservations;
using RoomReservation.Models.Dtos.Responses.Reservations;
using RoomReservation.Models.Entities;
using RoomReservation.Models.Enums;
using RoomReservation.Services.Interfaces;

namespace RoomReservation.Services.Implementations;

public class ReservationService: IReservationService
{
    private readonly ApplicationDbContext _context;
    public ReservationService( ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ReservationResponse> CreateAsync(CreateReservationRequest request)
    {
        if (request.StartTime >= request.EndTime)
            throw new ArgumentException("StartTime must be before EndTime");
        var room = await _context.Rooms
            .FirstOrDefaultAsync(r => r.Id == request.RoomId);

        if (room == null)
            throw new ArgumentException("Room does not exist");

        if (room.Status != RoomStatus.Available)
            throw new ArgumentException($"Room is {room.Status}");
        
        var overlap = await _context.Reservations.AnyAsync(r =>
            r.RoomId == request.RoomId &&
            request.StartTime < r.EndTime &&
            request.EndTime > r.StartTime);

        if (overlap)
            throw new ArgumentException("Room already reserved for this time");
        var reservation = new Reservation
        {
            RoomId = request.RoomId,
            StartTime = request.StartTime,
            EndTime = request.EndTime,

        };
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        return new ReservationResponse
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime,
                
        };
    }
    public async Task<ReservationResponse> GetByIdAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);

        if (reservation == null)
            throw new ArgumentException("Reservation does not exist");

        return new ReservationResponse
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime
        };
    }
    public async Task<ReservationResponse> UpdateAsync(int id, UpdateReservationRequest request)
    {
        var reservation = await _context.Reservations.FindAsync(id);

        if (reservation == null)
            throw new ArgumentException("Reservation does not exist");
        if (request.StartTime >= request.EndTime)
            throw new ArgumentException("StartTime must be before EndTime");
        var overlap = await _context.Reservations.AnyAsync(r =>
            r.RoomId == reservation.RoomId &&
            r.Id != id && 
            request.StartTime < r.EndTime &&
            request.EndTime > r.StartTime);

        if (overlap)
            throw new ArgumentException("Room already reserved for this time");
        reservation.StartTime = request.StartTime;
        reservation.EndTime = request.EndTime;
        await _context.SaveChangesAsync();
        return new ReservationResponse
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime
        };
    }

    public async Task DeleteAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)    
            throw new ArgumentException("Reservation does not exist");
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }
    
}