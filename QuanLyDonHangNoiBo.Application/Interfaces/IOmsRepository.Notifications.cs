
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<NotificationItem> Notifications { get; }
    NotificationItem AddNotification(NotificationItem notification);
}

