namespace QuanLyDonHangNoiBo.Application.Features.Dashboard.Common;

public sealed record OperationalAlertDto(string Title, string Message, NotificationSeverity Severity, string Link);


