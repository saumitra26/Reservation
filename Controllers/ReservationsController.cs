using Microsoft.AspNetCore.Mvc;
using RoomReservation.Models.Dtos.Request.Reservations;
using RoomReservation.Models.Dtos.Responses.Reservations;
using RoomReservation.Services.Interfaces;

namespace RoomReservation.Controllers;
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
       var result = await _reservationService.CreateAsync(request);
       return CreatedAtAction(nameof(Create),new { id = result.Id },
           result );
      }
      [HttpGet("{id}")]
      public async Task<ActionResult<ReservationResponse>> GetById(int id)
      {
          var result = await _reservationService.GetByIdAsync(id);
          return Ok(result);
      }
      [HttpPut("{id}")]
      public async Task<ActionResult<ReservationResponse>> Update(int id, [FromBody] UpdateReservationRequest request)
      {
          var result = await _reservationService.UpdateAsync(id, request);
          return Ok(result);
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
          await _reservationService.DeleteAsync(id);
          return NoContent();
      }

}