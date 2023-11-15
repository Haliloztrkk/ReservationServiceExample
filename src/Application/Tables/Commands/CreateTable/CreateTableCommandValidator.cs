using FluentValidation;

namespace ReservationService.Application.Tables.Commands.CreateTable;

public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
{
    public CreateTableCommandValidator()
    {
        RuleFor(v => v.Number)
            .GreaterThanOrEqualTo(1).WithMessage("Number at least greater than or equal to 1.");

        RuleFor(v => v.Capacity)
            .GreaterThanOrEqualTo(1).WithMessage("NumberOfGuest at least greater than or equal to 1.");
    }
}
