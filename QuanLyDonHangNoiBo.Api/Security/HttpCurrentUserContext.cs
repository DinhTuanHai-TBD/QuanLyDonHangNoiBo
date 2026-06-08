using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using QuanLyDonHangNoiBo.Application.Common.Security;
using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Api.Security;

public sealed class HttpCurrentUserContext : ICurrentUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpCurrentUserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    public bool IsAuthenticated => User?.Identity?.IsAuthenticated == true;

    public Guid? UserId =>
        TryGetGuid(JwtRegisteredClaimNames.Sub) ??
        TryGetGuid(ClaimTypes.NameIdentifier);

    public Guid? TenantId => TryGetGuid(JwtClaimTypes.TenantId);

    public string? TenantCode => User?.FindFirst(JwtClaimTypes.TenantCode)?.Value;

    public UserRole? Role
    {
        get
        {
            var roleValue = FindFirstValue(ClaimTypes.Role, "role", "roles");
            return Enum.TryParse<UserRole>(roleValue, ignoreCase: true, out var role) ? role : null;
        }
    }

    public IReadOnlySet<string> Permissions =>
        User?.FindAll(JwtClaimTypes.Permission)
            .Select(item => item.Value)
            .Where(item => !string.IsNullOrWhiteSpace(item))
            .ToHashSet(StringComparer.OrdinalIgnoreCase)
        ?? new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    private Guid? TryGetGuid(string claimType)
    {
        var value = User?.FindFirst(claimType)?.Value;
        return Guid.TryParse(value, out var parsed) ? parsed : null;
    }

    private string? FindFirstValue(params string[] claimTypes)
    {
        return claimTypes
            .Select(claimType => User?.FindFirst(claimType)?.Value)
            .FirstOrDefault(value => !string.IsNullOrWhiteSpace(value));
    }
}
