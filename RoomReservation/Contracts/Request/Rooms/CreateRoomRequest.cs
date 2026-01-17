using System.ComponentModel.DataAnnotations;
namespace RoomReservation.Contracts.Request.Rooms;

public class CreateRoomRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(500)]
    public string? Description { get; set; }
}