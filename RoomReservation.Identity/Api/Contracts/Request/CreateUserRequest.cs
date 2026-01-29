using System.ComponentModel.DataAnnotations;

namespace RoomReservation.Identity.Api.Contracts.Request;

public class CreateUserRequest
{
    [Required]
    [StringLength(30)]
    public string UserName { get; set; } = null!;

    [Required]
    [StringLength(20, MinimumLength = 8)]
    public string Password { get; set; } = null!;

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(128)]
    public string Email { get; set; } = null!;
}