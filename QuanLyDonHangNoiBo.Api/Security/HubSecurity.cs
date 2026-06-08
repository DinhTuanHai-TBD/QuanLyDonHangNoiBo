using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Api.Security;

internal static class HubSecurity
{
    public static void EnsureTenantAccess(HubCallerContext context, Guid tenantId)
    {
        if (GetRole(context) == UserRole.SuperAdmin)
        {
            return;
        }

        if (GetTenantId(context) != tenantId)
        {
            throw new HubException("Khong co quyen tham gia nhom tenant nay.");
        }
    }

    public static void EnsureRoleAccess(HubCallerContext context, Guid tenantId, string role)
    {
        EnsureTenantAccess(context, tenantId);

        if (GetRole(context) == UserRole.SuperAdmin)
        {
            return;
        }

        if (!Enum.TryParse<UserRole>(role, ignoreCase: true, out var requestedRole) ||
            GetRole(context) != requestedRole)
        {
            throw new HubException("Khong co quyen tham gia nhom role nay.");
        }
    }

    public static void EnsureDriverAccess(HubCallerContext context, Guid tenantId, Guid driverId)
    {
        EnsureTenantAccess(context, tenantId);

        var role = GetRole(context);
        if (role is UserRole.SuperAdmin or UserRole.Dispatcher)
        {
            return;
        }

        if (role != UserRole.Driver || GetUserId(context) != driverId)
        {
            throw new HubException("Khong co quyen tham gia nhom tai xe nay.");
        }
    }

    public static void EnsureCurrentUserRole(HubCallerContext context, Guid tenantId, UserRole requiredRole)
    {
        EnsureTenantAccess(context, tenantId);

        var role = GetRole(context);
        if (role != UserRole.SuperAdmin && role != requiredRole)
        {
            throw new HubException("Khong co quyen tham gia nhom nay.");
        }
    }

    public static void EnsureUserAccess(HubCallerContext context, Guid tenantId, Guid userId)
    {
        EnsureTenantAccess(context, tenantId);

        if (GetRole(context) == UserRole.SuperAdmin)
        {
            return;
        }

        if (GetUserId(context) != userId)
        {
            throw new HubException("Khong co quyen tham gia nhom user nay.");
        }
    }

    private static Guid? GetTenantId(HubCallerContext context)
    {
        return TryGetGuid(context.User, JwtClaimTypes.TenantId);
    }

    private static Guid? GetUserId(HubCallerContext context)
    {
        return TryGetGuid(context.User, JwtRegisteredClaimNames.Sub) ??
            TryGetGuid(context.User, ClaimTypes.NameIdentifier);
    }

    private static UserRole? GetRole(HubCallerContext context)
    {
        var value =
            context.User?.FindFirst(ClaimTypes.Role)?.Value ??
            context.User?.FindFirst("role")?.Value ??
            context.User?.FindFirst("roles")?.Value;
        return Enum.TryParse<UserRole>(value, ignoreCase: true, out var role) ? role : null;
    }

    private static Guid? TryGetGuid(ClaimsPrincipal? user, string claimType)
    {
        var value = user?.FindFirst(claimType)?.Value;
        return Guid.TryParse(value, out var parsed) ? parsed : null;
    }
}
