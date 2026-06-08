using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Api.Hubs;

[Authorize]
public sealed class DeliveryHub : Hub
{
    public Task JoinTenant(Guid tenantId)
    {
        HubSecurity.EnsureTenantAccess(Context, tenantId);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"tenant:{tenantId}");
    }

    public Task JoinDriver(Guid tenantId, Guid driverId)
    {
        HubSecurity.EnsureDriverAccess(Context, tenantId, driverId);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"driver:{tenantId}:{driverId}");
    }

    public Task JoinDispatcher(Guid tenantId)
    {
        HubSecurity.EnsureCurrentUserRole(Context, tenantId, UserRole.Dispatcher);
        return Groups.AddToGroupAsync(Context.ConnectionId, $"role:{tenantId}:Dispatcher");
    }

    public Task PublishDriverLocation(Guid tenantId, Guid driverId, Guid shipmentId, double latitude, double longitude)
    {
        HubSecurity.EnsureDriverAccess(Context, tenantId, driverId);
        return Clients.Group($"role:{tenantId}:Dispatcher").SendAsync("DriverLocationUpdated", new
        {
            tenantId,
            driverId,
            shipmentId,
            lat = latitude,
            lng = longitude,
            recordedAt = DateTimeOffset.UtcNow
        });
    }
}





