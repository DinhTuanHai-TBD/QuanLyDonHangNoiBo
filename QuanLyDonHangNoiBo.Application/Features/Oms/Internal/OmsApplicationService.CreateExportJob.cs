namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ExportJobDto CreateExportJob(CreateExportJobRequest request)
    {
        var tenantId = ResolveTenantId(request.TenantId);
        var type = string.IsNullOrWhiteSpace(request.ExportType) ? "orders" : request.ExportType.Trim().ToLowerInvariant();
        var count = type switch
        {
            "orders" => _repository.Orders.Count(item => item.TenantId == tenantId),
            "customers" => _repository.Customers.Count(item => item.TenantId == tenantId),
            "products" => _repository.Products.Count(item => item.TenantId == tenantId),
            "inventory" => _repository.InventoryStocks.Count(item => item.TenantId == tenantId),
            "cod" => _repository.CodCollections.Count(item => item.TenantId == tenantId),
            "returns" => _repository.Returns.Count(item => item.TenantId == tenantId),
            _ => throw new InvalidOperationException("Export type khong ho tro.")
        };

        var export = new ExportJob
        {
            TenantId = tenantId,
            RequestedByUserId = request.RequestedByUserId,
            ExportCode = $"EXP-{DateTimeOffset.UtcNow:yyMMdd}-{_repository.ExportJobs.Count(item => item.TenantId == tenantId) + 1:0000}",
            ExportType = type,
            Status = ExportJobStatus.Completed,
            FileName = $"{type}-{DateTimeOffset.UtcNow:yyyyMMddHHmmss}.xlsx",
            Summary = $"Demo export {count} {type} records.",
            CreatedAt = DateTimeOffset.UtcNow,
            CompletedAt = DateTimeOffset.UtcNow
        };
        export.DownloadUrl = $"/exports/{export.FileName}";

        _repository.AddExportJob(export);
        return ToExportJobDto(export);
    }
}

