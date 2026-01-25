using System.ComponentModel.DataAnnotations;

namespace RoomReservation.Api.Contracts.Request.Authentication;

public class LoginRequest
{
    [Required] 
    [EmailAddress] 
    public string Email { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}