using System.Reflection;
using ReservationService.Application.Common.Interfaces;
using ReservationService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReservationService.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Table> Tables => Set<Table>();

    public DbSet<Reservation> Reservations => Set<Reservation>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ReservationServiceDb");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
