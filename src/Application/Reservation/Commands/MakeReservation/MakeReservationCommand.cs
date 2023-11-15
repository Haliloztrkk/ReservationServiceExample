using MediatR;
using ReservationService.Application.Common.Interfaces;
using ReservationService.Application.Common.Models;

namespace ReservationService.Application.Reservation.Commands.MakeReservation;

public record MakeReservationCommand : IRequest<Result<int>>
{
    public string CustomerName { get; set; }
    public DateTime ReservationDate { get; set; }
    public int NumberOfGuests { get; set; }
}

public class MakeReservationCommandHandler : IRequestHandler<MakeReservationCommand, Result<int>>
{
    private readonly IMakeReservationService _reservationService;

    public MakeReservationCommandHandler(IMakeReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public async Task<Result<int>> Handle(MakeReservationCommand request, CancellationToken cancellationToken)
    {
        var result = await _reservationService.MakeReservationAsync(request, cancellationToken);
        return result;
    }
}
