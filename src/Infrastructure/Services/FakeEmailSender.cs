using Microsoft.Extensions.Logging;
using ReservationService.Application.Common.Interfaces;

namespace ReservationService.Infrastructure.Services;
public class FakeEmailSender : IEmailSender
{
    private readonly ILogger<FakeEmailSender> _logger;
    public FakeEmailSender(ILogger<FakeEmailSender> logger)
    {
        _logger = logger;
    }
    public Task SendEmailAsync(string to, string from, string subject, string body, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Not actually sending an email to {to} from {from} with subject {subject}", to, from, subject);
        return Task.CompletedTask;
    }
}
