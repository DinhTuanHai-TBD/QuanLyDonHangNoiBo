namespace QuanLyDonHangNoiBo.Application.Features.Ai.Common;

public sealed record AiInsightDto(Guid Id, string Title, string Summary, NotificationSeverity Severity, string Link, DateTimeOffset CreatedAt);


