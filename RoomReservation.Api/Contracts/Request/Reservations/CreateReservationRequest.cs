using System.ComponentModel.DataAnnotations;

namespace RoomReservation.Api.Contracts.Request.Reservations;

public class CreateReservationRequest
{
    [Required]
    
    public int RoomId { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }
}