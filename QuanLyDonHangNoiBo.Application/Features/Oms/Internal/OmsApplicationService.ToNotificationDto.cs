namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static NotificationDto ToNotificationDto(NotificationItem notification)
    {
        return new NotificationDto(notification.Id, notification.Title, notification.Message, notification.Severity, notification.Link, notification.IsRead, notification.CreatedAt);
    }
}

