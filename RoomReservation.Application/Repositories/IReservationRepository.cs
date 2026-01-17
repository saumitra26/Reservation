using RoomReservation.Domain.Entities;

namespace RoomReservation.Application.Repositories;

public interface IReservationRepository
{
    Task<bool>HasOverlappingReservations(int roomId, DateTime startDate, DateTime sndDate);
    Task<Reservation> AddAsync(Reservation reservation);
    Task<Reservation?> GetByIdAsync(int id);
    Task<Reservation>UpdateAsync(Reservation reservation);
    Task DeleteAsync(int id);
}