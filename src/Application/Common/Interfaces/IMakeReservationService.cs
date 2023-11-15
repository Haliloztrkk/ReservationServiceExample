using ReservationService.Application.Common.Models;
using ReservationService.Application.Reservation.Commands.MakeReservation;

namespace ReservationService.Application.Common.Interfaces;

public interface IMakeReservationService
{
    Task<Result<int>> MakeReservationAsync(MakeReservationCommand request, CancellationToken cancellationToken = default);
}
