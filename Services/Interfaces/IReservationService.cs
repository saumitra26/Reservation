using RoomReservation.Models.Dtos.Request.Reservations;
using RoomReservation.Models.Dtos.Responses.Reservations;

namespace RoomReservation.Services.Interfaces;

public interface IReservationService
{
    Task<ReservationResponse> CreateAsync(CreateReservationRequest request);
    Task<ReservationResponse> GetByIdAsync(int id);
    Task<ReservationResponse>UpdateAsync(int id, UpdateReservationRequest request);
    Task DeleteAsync(int id);

}