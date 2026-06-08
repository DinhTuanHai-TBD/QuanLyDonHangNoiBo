namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<ExportJobDto> GetExportJobs(Guid? tenantId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        return _repository.ExportJobs
            .Where(item => item.TenantId == resolvedTenantId)
            .OrderByDescending(item => item.CreatedAt)
            .Select(ToExportJobDto)
            .ToList();
    }
}

