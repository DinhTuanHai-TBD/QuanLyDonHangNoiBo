namespace QuanLyDonHangNoiBo.Application.Features.Notifications.Common;

public sealed record NotificationDto(Guid Id, string Title, string Message, NotificationSeverity Severity, string Link, bool IsRead, DateTimeOffset CreatedAt);


