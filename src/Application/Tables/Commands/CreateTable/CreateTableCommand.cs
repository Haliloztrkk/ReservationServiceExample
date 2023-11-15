using MediatR;
using ReservationService.Application.Common.Interfaces;
using ReservationService.Domain.Entities;

namespace ReservationService.Application.Tables.Commands.CreateTable;

public record CreateTableCommand : IRequest<int>
{
    public int Number { get; set; }
    public int Capacity { get; set; }
}

public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTableCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTableCommand request, CancellationToken cancellationToken)
    {
        var entity = new Table
        {
            Number = request.Number,
            Capacity = request.Capacity
        };

        _context.Tables.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
