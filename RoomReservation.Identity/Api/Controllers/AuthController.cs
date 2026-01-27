using Microsoft.AspNetCore.Mvc;
using RoomReservation.Identity.Api.Contracts.Request;
using RoomReservation.Identity.Api.Contracts.Response;
using RoomReservation.Identity.Application.Interface;
using RoomReservation.Identity.Application.Models;

namespace RoomReservation.Identity.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController:ControllerBase
{
   
    private readonly IAuthService _authService;
    public AuthController( IAuthService authService)
    {
        _authService = authService;
        
    }

    [HttpPost("register")]
    public async Task<IActionResult> AddUser([FromBody] CreateUserRequest request)
    {
        var user = new RegisterUserCommand
        {
            UserName = request.UserName,
            Email = request.Email,
            Password = request.Password
        };
        await _authService.AddUserAsync(user);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request )
    {
        var loginData = new AuthCredentials
        {
            Email = request.Email,
            Password = request.Password
        };
        var token = await _authService.LoginAsync(loginData);
        if (token == null)
            return Unauthorized("Invalid Email or Password");
        var response = new LoginResponse
        {
            AccessToken = token
        };
        return Ok(response);
    }

}