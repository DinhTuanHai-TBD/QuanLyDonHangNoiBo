using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class ExportJob
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public Guid? RequestedByUserId { get; set; }
    public string ExportCode { get; set; } = "";
    public string ExportType { get; set; } = "";
    public ExportJobStatus Status { get; set; } = ExportJobStatus.Pending;
    public string FileName { get; set; } = "";
    public string DownloadUrl { get; set; } = "";
    public string Summary { get; set; } = "";
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? CompletedAt { get; set; }
}




