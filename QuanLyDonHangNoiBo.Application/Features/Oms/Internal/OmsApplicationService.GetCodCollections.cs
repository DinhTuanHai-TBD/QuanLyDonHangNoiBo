namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<CodCollectionDto> GetCodCollections(Guid? tenantId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        return _repository.CodCollections
            .Where(item => item.TenantId == resolvedTenantId)
            .OrderByDescending(item => item.CollectedAt ?? DateTimeOffset.MinValue)
            .Select(ToCodDto)
            .ToList();
    }
}

