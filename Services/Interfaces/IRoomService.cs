using RoomReservation.Models.Dtos.Request.Reservations;
using RoomReservation.Models.Dtos.Request.Rooms;
using RoomReservation.Models.Dtos.Responses.Rooms;

namespace RoomReservation.Services.Interfaces;

public interface IRoomService
{
   Task<RoomResponse> CreateAsync(CreateRoomRequest request);
}