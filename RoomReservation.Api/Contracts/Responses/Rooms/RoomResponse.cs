

using RoomReservation.Domain.Entities.Enum;


namespace RoomReservation.Api.Contracts.Responses.Rooms;

public class RoomResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public RoomStatus Status { get; set; }

}