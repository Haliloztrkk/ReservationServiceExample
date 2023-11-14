using ReservationService.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace ReservationService.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId ?? string.Empty;
        var userName = string.Empty;

        if (!string.IsNullOrEmpty(userId))
        {
            userName = _currentUserService.UserName ?? string.Empty;
        }

        _logger.LogInformation("ReservationService Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);
    }
}
