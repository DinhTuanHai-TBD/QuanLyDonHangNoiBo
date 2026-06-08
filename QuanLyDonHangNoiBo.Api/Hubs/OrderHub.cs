using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using QuanLyDonHangNoiBo.Api.Security;

namespace QuanLyDonHangNoiBo.Api.Hubs;

 [Authorize]
public sealed class OrderHub : Hub
{
    public Task JoinTenant(Guid tenantId)
    {
        HubSecurity.EnsureTenantAccess(Context, tenantId);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"tenant:{tenantId}");
    }

    public Task JoinWarehouse(Guid tenantId, Guid warehouseId)
    {
        HubSecurity.EnsureTenantAccess(Context, tenantId);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"warehouse:{tenantId}:{warehouseId}");
    }

    public Task JoinOrder(Guid tenantId, Guid orderId)
    {
        HubSecurity.EnsureTenantAccess(Context, tenantId);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"order:{tenantId}:{orderId}");
    }

    public Task LeaveOrder(Guid tenantId, Guid orderId)
    {
        HubSecurity.EnsureTenantAccess(Context, tenantId);
        return Groups.RemoveFromGroupAsync(Context.ConnectionId, $"order:{tenantId}:{orderId}");
    }
}





