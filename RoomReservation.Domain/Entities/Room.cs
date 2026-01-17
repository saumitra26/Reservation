using RoomReservation.Domain.Entities;
using RoomReservation.Domain.Entities.Enum;

namespace RoomReservation.Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public  string Name { get; set; } 
    public required string Description { get; set; }
    public RoomStatus Status { get; set; } = RoomStatus.Available;
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}