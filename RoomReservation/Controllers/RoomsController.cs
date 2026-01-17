using Microsoft.AspNetCore.Mvc;
using RoomReservation.Application.Interfaces;
using RoomReservation.Contracts.Request.Rooms;
using RoomReservation.Contracts.Responses.Rooms;
using RoomReservation.Domain.Entities;
using RoomReservation.Domain.Entities.Enum;


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
    public async Task<ActionResult<RoomResponse>> Create([FromBody] CreateRoomRequest request)
    {
        var room = new Room
        {
            Name = request.Name,
            Description = request.Description,
            Status = RoomStatus.Available

        };
      var result= await _roomService.CreateAsync(room);
      var response = new RoomResponse
      {
          Id = result.Id,
          Name = result.Name,
          Description = result.Description,
          Status = result.Status
      };
      return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomResponse>> GetById(int id)
    {
        var result = await _roomService.GetByIdAsync(id);
        if (result == null)
            return NotFound();

        var response = new RoomResponse
        {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description,
            Status = result.Status
        };
            return Ok(response);
    }
}

