namespace RoomReservation.Models.Entities;

public class Reservation
{
    public int Id { get; set; }

    public int RoomId { get; set; }
    public  Room Room { get; set; } = null!;

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; } 
}