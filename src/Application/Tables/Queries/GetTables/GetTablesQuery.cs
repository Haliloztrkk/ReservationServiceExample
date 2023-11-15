using AutoMapper;
using MediatR;
using ReservationService.Application.Common.Interfaces;
using ReservationService.Application.Common.Mappings;

namespace ReservationService.Application.Tables.Queries.GetTables;

public record GetTablesQuery() : IRequest<IReadOnlyCollection<TableDto>>;

public class GetTablesQueryHandler : IRequestHandler<GetTablesQuery, IReadOnlyCollection<TableDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTablesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<TableDto>> Handle(GetTablesQuery request, CancellationToken cancellationToken)
    {
        var tables = await _context.Tables
            .ProjectToListAsync<TableDto>(_mapper.ConfigurationProvider, cancellationToken);
        return tables;
    }
}
