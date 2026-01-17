
using RoomReservation.Application.Interfaces;
using RoomReservation.Application.Repositories;
using RoomReservation.Domain.Entities;
using RoomReservation.Domain.Entities.Enum;


namespace RoomReservation.Application.Services;

public class ReservationService : IReservationService
{
 private readonly IReservationRepository _reservationRepository;
 private readonly IRoomRepository _roomRepository;

    public ReservationService(IReservationRepository reservationRepository, IRoomRepository roomRepository)
    {
        _reservationRepository = reservationRepository;
        _roomRepository = roomRepository;

    }

    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        if (reservation.StartTime >= reservation.EndTime)
            throw new ArgumentException("StartTime must be before EndTime");

        var room = await _roomRepository.GetByIdAsync(reservation.RoomId);

        if (room == null)
            throw new ArgumentException("Room does not exist");

        if (room.Status != RoomStatus.Available)
            throw new ArgumentException($"Room is {room.Status}");

        var overlap = await _reservationRepository.HasOverlappingReservations(room.Id, reservation.StartTime, reservation.EndTime);

        if (overlap)
            throw new ArgumentException("Room already reserved for this time");

       

        return await _reservationRepository.AddAsync(reservation);
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        return await _reservationRepository.GetByIdAsync(id);
    }

  
    public async Task<Reservation> UpdateAsync(Reservation reservation)
    {
        var existing = await _reservationRepository.GetByIdAsync(reservation.Id);

        if (existing == null)
            throw new ArgumentException("Reservation does not exist");

        if (reservation.StartTime >= reservation.EndTime)
            throw new ArgumentException("StartTime must be before EndTime");

        var overlap = await _reservationRepository.HasOverlappingReservations(existing.Id, reservation.StartTime, reservation.EndTime);

        if (overlap)
            throw new ArgumentException("Room already reserved for this time");

        existing.StartTime = reservation.StartTime;
        existing.EndTime = reservation.EndTime;

        return await _reservationRepository.UpdateAsync(existing);
        
    }

    public async Task DeleteAsync(int id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id);

        if (reservation == null)
            throw new ArgumentException("Reservation does not exist");

        await _reservationRepository.DeleteAsync(id);
    }
}

