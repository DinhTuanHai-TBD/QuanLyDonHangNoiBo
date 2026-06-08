namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<WarehouseDto> GetWarehouses(Guid? tenantId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        return _repository.Warehouses
            .Where(item => item.TenantId == resolvedTenantId)
            .OrderBy(item => item.Code)
            .Select(ToWarehouseDto)
            .ToList();
    }
}

