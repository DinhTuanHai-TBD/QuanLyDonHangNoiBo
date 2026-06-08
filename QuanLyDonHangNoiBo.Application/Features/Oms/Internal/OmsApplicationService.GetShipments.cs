namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<ShipmentDto> GetShipments(Guid? tenantId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        return _repository.Shipments
            .Where(item => item.TenantId == resolvedTenantId)
            .OrderByDescending(item => item.UpdatedAt)
            .Select(ToShipmentDto)
            .ToList();
    }
}

