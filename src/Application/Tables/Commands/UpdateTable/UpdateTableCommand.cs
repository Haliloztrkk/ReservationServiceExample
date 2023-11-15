using MediatR;
using Microsoft.EntityFrameworkCore;
using ReservationService.Application.Common.Exceptions;
using ReservationService.Application.Common.Interfaces;
using ReservationService.Domain.Entities;

namespace ReservationService.Application.Tables.Commands.UpdateTable;

public record UpdateTableCommand : IRequest
{
    public int Number { get; set; }

    public int Capacity { get; set; }
}

public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTableCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTableCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tables
            .FirstOrDefaultAsync(x => x.Number == request.Number, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Table), request.Number);
        }

        entity.Capacity = request.Capacity;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
