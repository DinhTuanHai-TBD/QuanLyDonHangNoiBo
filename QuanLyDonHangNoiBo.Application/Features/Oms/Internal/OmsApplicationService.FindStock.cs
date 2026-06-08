namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private InventoryStock FindStock(Guid tenantId, Guid warehouseId, Guid skuId)
    {
        return _repository.InventoryStocks.FirstOrDefault(item =>
            item.TenantId == tenantId &&
            item.WarehouseId == warehouseId &&
            item.SkuId == skuId)
            ?? throw new InvalidOperationException("Khong tim thay ton kho cho SKU.");
    }
}

