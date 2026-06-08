namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private Warehouse FindWarehouse(Guid warehouseId)
    {
        var warehouse = _repository.Warehouses.FirstOrDefault(item => item.Id == warehouseId)
            ?? throw new KeyNotFoundException("Kho khong ton tai.");
        EnsureCanAccessTenant(warehouse.TenantId);
        return warehouse;
    }
}

