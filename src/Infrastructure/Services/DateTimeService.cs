using ReservationService.Application.Common.Interfaces;

namespace ReservationService.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
