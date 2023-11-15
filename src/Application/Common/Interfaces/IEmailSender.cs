namespace ReservationService.Application.Common.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string to, string from, string subject, string body,
        CancellationToken cancellationToken = default);
}
