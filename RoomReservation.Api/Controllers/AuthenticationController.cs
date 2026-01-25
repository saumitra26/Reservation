using Microsoft.AspNetCore.Mvc;
using RoomReservation.Api.Contracts.Request.Authentication;
using RoomReservation.Api.Contracts.Responses.Authentication;
using RoomReservation.Application.Interfaces;

namespace RoomReservation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController: ControllerBase
{
    private readonly IAuthService _authService;
    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> AddUser([FromBody] CreateUserRequest request)
    {
        await _authService.RegisterAsync(request.UserName, request.Email, request.Password);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result =await _authService.LoginAsync(request.Email, request.Password);
        if (result == null)
            return Unauthorized("Invalid email or password");
        var response = new LoginResponse
        {
            AccessToken = result
        };
        return Ok(response);
    }
}

