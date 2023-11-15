using MediatR;
using Microsoft.EntityFrameworkCore;
using ReservationService.Application.Common.Exceptions;
using ReservationService.Application.Common.Interfaces;
using ReservationService.Domain.Entities;

namespace ReservationService.Application.Tables.Commands.DeleteTable;

public record DeleteTableCommand(int Number) : IRequest;

public class DeleteTableCommandHandler : IRequestHandler<DeleteTableCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTableCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTableCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tables
            .FirstOrDefaultAsync(x => x.Number == request.Number, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Table), request.Number);
        }

        _context.Tables.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
