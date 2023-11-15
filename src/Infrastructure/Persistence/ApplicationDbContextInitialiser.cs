using ReservationService.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace ReservationService.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        if (!_context.Tables.Any())
        {
            var rnd = new Random();
            for (int i = 1; i <= 10; i++)
            {
                _context.Tables.Add(new Table
                {
                    Id = i,
                    Number = i,
                    Capacity = rnd.Next(1, 10)
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
