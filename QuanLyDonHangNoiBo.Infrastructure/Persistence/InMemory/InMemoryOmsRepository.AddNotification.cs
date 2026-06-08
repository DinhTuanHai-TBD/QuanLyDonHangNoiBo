using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public NotificationItem AddNotification(NotificationItem notification)
    {
        lock (_sync)
        {
            _notifications.Add(notification);
        }

        return notification;
    }
}



