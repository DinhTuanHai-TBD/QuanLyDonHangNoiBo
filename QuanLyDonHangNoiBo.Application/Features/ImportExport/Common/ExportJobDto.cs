namespace QuanLyDonHangNoiBo.Application.Features.ImportExport.Common;

public sealed record ExportJobDto(
    Guid Id,
    Guid TenantId,
    string ExportCode,
    string ExportType,
    ExportJobStatus Status,
    string FileName,
    string DownloadUrl,
    string Summary,
    DateTimeOffset CreatedAt,
    DateTimeOffset? CompletedAt);


