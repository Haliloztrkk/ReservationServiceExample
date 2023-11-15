using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReservationService.Domain.Entities;

namespace ReservationService.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Table> Tables { get; }

    DbSet<Domain.Entities.Reservation> Reservations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
