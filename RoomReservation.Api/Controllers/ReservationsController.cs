using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomReservation.Api.Contracts.Request.Reservations;
using RoomReservation.Api.Contracts.Responses.Reservations;
using RoomReservation.Application.Interfaces;
using RoomReservation.Domain.Entities;


namespace RoomReservation.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReservationsController:ControllerBase
{
    private readonly IReservationService _reservationService;
   public ReservationsController( IReservationService reservationService)
   {
       _reservationService = reservationService;
   }

   
      [HttpPost]
      public async Task<ActionResult<ReservationResponse>> Create( [FromBody] CreateReservationRequest request)
      {
          try
          {
              var reservation = new Reservation
              {
                  StartTime = request.StartTime,
                  EndTime = request.EndTime,
                  RoomId = request.RoomId,
              };

              var result = await _reservationService.CreateAsync(reservation);

              var response = new ReservationResponse
              {
                  Id = result.Id,
                  StartTime = result.StartTime,
                  EndTime = result.EndTime,
                  RoomId = result.RoomId,
              };

              return CreatedAtAction(nameof(GetById), new { id = result.Id }, response);
          }
          catch (ArgumentException ex)
          {
              return BadRequest(ex.Message); // 🔥 fixes 500
          }
      }
      [HttpGet("{id}")]
      public async Task<ActionResult<ReservationResponse>> GetById(int id)
      {
          var result = await _reservationService.GetByIdAsync(id);
          if(result == null)
              return NotFound();
          var response = new ReservationResponse
          {
              Id = result.Id,
              StartTime = result.StartTime,
              EndTime = result.EndTime,
              RoomId = result.RoomId,
          };
          return Ok(response);
      }
      [HttpPut("{id}")]
      public async Task<ActionResult<ReservationResponse>> Update(int id, [FromBody] UpdateReservationRequest request)
      {
          var reservation = await _reservationService.GetByIdAsync(id);

          if (reservation == null)
              return NotFound();

          reservation.StartTime = request.StartTime;
          reservation.EndTime = request.EndTime;

          var updated = await _reservationService.UpdateAsync(reservation);
          var response = new ReservationResponse
          {
              Id = updated.Id,
              RoomId = updated.RoomId,
              StartTime = updated.StartTime,
              EndTime = updated.EndTime
          };

          return Ok(response);
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
          await _reservationService.DeleteAsync(id);
          return NoContent();
      }

}