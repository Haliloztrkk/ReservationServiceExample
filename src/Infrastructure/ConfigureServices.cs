using ReservationService.Application.Common.Interfaces;
using ReservationService.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using ReservationService.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>();

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IEmailSender, FakeEmailSender>();

        return services;
    }
}
