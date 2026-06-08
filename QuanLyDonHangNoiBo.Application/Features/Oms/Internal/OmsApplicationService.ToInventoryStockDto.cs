namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private InventoryStockDto ToInventoryStockDto(InventoryStock stock)
    {
        var warehouse = _repository.Warehouses.First(item => item.Id == stock.WarehouseId);
        var sku = _repository.Skus.First(item => item.Id == stock.SkuId);
        var product = _repository.Products.First(item => item.Id == sku.ProductId);

        return new InventoryStockDto(
            stock.Id,
            stock.TenantId,
            stock.WarehouseId,
            warehouse.Code,
            warehouse.Name,
            stock.SkuId,
            sku.SkuCode,
            $"{product.Name} - {sku.Name}",
            stock.OnHand,
            stock.Reserved,
            stock.Available,
            sku.LowStockThreshold,
            stock.Available <= sku.LowStockThreshold,
            stock.UpdatedAt);
    }
}

