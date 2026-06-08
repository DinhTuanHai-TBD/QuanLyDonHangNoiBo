using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Api.Hubs;

[Authorize]
public sealed class DashboardHub : Hub
{
    public Task JoinTenant(Guid tenantId)
    {
        HubSecurity.EnsureTenantAccess(Context, tenantId);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"tenant:{tenantId}");
    }

    public Task JoinManagerDashboard(Guid tenantId)
    {
        HubSecurity.EnsureCurrentUserRole(Context, tenantId, UserRole.Manager);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"role:{tenantId}:Manager");
    }
}





