namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<PackageDto> GetPackages(Guid? tenantId, Guid? orderId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var query = _repository.Packages.Where(item => item.TenantId == resolvedTenantId);
        if (orderId.HasValue)
        {
            query = query.Where(item => item.OrderId == orderId.Value);
        }

        return query.OrderByDescending(item => item.CreatedAt).Select(ToPackageDto).ToList();
    }
}

