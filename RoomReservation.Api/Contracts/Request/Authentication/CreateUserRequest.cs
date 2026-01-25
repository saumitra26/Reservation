using System.ComponentModel.DataAnnotations;

namespace RoomReservation.Api.Contracts.Request.Authentication;

public class CreateUserRequest
{
    [Required]
    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; set; } = null!;
}
