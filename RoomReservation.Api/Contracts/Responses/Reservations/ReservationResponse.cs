namespace RoomReservation.Api.Contracts.Responses.Reservations; 

public class ReservationResponse
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}