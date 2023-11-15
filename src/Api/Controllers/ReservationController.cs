using Microsoft.AspNetCore.Mvc;
using ReservationService.Application.Common.Models;
using ReservationService.Application.Reservation.Commands.MakeReservation;

namespace ReservationService.Api.Controllers;

public class ReservationController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Result<int>>> MakeReservation(MakeReservationCommand command)
    {
        return await Mediator.Send(command);
    }
}
