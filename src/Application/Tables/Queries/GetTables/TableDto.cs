using ReservationService.Application.Common.Mappings;
using ReservationService.Domain.Entities;

namespace ReservationService.Application.Tables.Queries.GetTables;

public class TableDto : IMapFrom<Table>
{
    public int Number { get; set; }

    public int Capacity { get; set; }
}
