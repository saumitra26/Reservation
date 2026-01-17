

using RoomReservation.Domain.Entities;

namespace RoomReservation.Application.Interfaces;

public interface IReservationService
{
    Task<Reservation> CreateAsync(Reservation reservation);
    Task<Reservation?> GetByIdAsync(int id);
    Task<Reservation> UpdateAsync(Reservation reservation);
    Task DeleteAsync(int id);
}