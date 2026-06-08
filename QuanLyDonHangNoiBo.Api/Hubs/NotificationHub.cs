using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using QuanLyDonHangNoiBo.Api.Security;

namespace QuanLyDonHangNoiBo.Api.Hubs;

[Authorize]
public sealed class NotificationHub : Hub
{
    public Task JoinTenant(Guid tenantId)
    {
        HubSecurity.EnsureTenantAccess(Context, tenantId);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"tenant:{tenantId}");
    }

    public Task JoinRole(Guid tenantId, string role)
    {
        HubSecurity.EnsureRoleAccess(Context, tenantId, role);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"role:{tenantId}:{role}");
    }

    public Task JoinUser(Guid tenantId, Guid userId)
    {
        HubSecurity.EnsureUserAccess(Context, tenantId, userId);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"user:{tenantId}:{userId}");
    }
}





