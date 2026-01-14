using Microsoft.AspNetCore.Mvc;
using RoomReservation.Models.Dtos.Request.Rooms;
using RoomReservation.Models.Dtos.Responses.Rooms;
using RoomReservation.Models.Entities;
using RoomReservation.Services.Interfaces;

namespace RoomReservation.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RoomsController: ControllerBase
{
 private readonly IRoomService _roomService;
    public RoomsController( IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost]
    public async Task<ActionResult<RoomResponse>> Create(CreateRoomRequest request)
    {
      var result= await _roomService.CreateAsync(request);
      return CreatedAtAction(nameof(Create), result);
    }
}
