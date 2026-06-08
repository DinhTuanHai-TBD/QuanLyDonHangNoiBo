namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<NotificationDto> GetNotifications(Guid? tenantId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        return _repository.Notifications
            .Where(item => item.TenantId == resolvedTenantId)
            .OrderByDescending(item => item.CreatedAt)
            .Take(20)
            .Select(ToNotificationDto)
            .ToList();
    }
}

