namespace RoomReservation.Contracts.Request.Reservations;

public class UpdateReservationRequest
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}