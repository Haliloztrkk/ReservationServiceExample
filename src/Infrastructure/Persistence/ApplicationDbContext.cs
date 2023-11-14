using System.Reflection;
using ReservationService.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ReservationService.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

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
