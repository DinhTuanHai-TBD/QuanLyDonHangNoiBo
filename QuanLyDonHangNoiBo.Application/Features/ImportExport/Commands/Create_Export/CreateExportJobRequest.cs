namespace QuanLyDonHangNoiBo.Application.Features.ImportExport.Commands.Create_Export;

public sealed class CreateExportJobRequest
{
    public Guid? TenantId { get; set; }
    public string ExportType { get; set; } = "orders";
    public Guid? RequestedByUserId { get; set; }
}


