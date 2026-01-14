using System.ComponentModel.DataAnnotations;

namespace RoomReservation.Models.Dtos.Request.Reservations;

public class CreateReservationRequest
{
    [Required]
    [Range(1, int.MaxValue)]
    public int RoomId { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }
}