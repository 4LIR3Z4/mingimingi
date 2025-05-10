using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LanguageLearning.Infrastructure.Security;
public sealed class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
        _httpContextAccessor = httpContextAccessor;
    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true;

    public long? UserId
    {
        get
        {
            var id = _httpContextAccessor.HttpContext?.User?
                         .FindFirstValue(ClaimTypes.NameIdentifier);
            return id is null ? null : long.Parse(id);
        }
    }
}
