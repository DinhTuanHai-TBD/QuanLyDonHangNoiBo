namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static ExportJobDto ToExportJobDto(ExportJob export)
    {
        return new ExportJobDto(export.Id, export.TenantId, export.ExportCode, export.ExportType, export.Status, export.FileName, export.DownloadUrl, export.Summary, export.CreatedAt, export.CompletedAt);
    }
}

