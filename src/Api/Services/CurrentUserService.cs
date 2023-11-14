using System.Security.Claims;
using ReservationService.Application.Common.Interfaces;

namespace ReservationService.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    public string? UserName => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
}
