using FluentValidation;

namespace ReservationService.Application.Reservation.Commands.MakeReservation;

public class MakeReservationCommandValidator : AbstractValidator<MakeReservationCommand>
{
    public MakeReservationCommandValidator()
    {
        RuleFor(v => v.CustomerName)
            .NotEmpty().WithMessage("CustomerName is required.");

        RuleFor(v => v.NumberOfGuests)
            .GreaterThanOrEqualTo(1).WithMessage("NumberOfGuests at least greater than or equal to 1.");
    }
}
