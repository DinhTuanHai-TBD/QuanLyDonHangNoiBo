namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<InventoryStockDto> GetInventoryStocks(Guid? tenantId, Guid? warehouseId, string? search)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var query = _repository.InventoryStocks.Where(item => item.TenantId == resolvedTenantId);

        if (warehouseId.HasValue)
        {
            query = query.Where(item => item.WarehouseId == warehouseId.Value);
        }

        var result = query.Select(ToInventoryStockDto).ToList();

        if (!string.IsNullOrWhiteSpace(search))
        {
            result = result.Where(item =>
                Contains(item.SkuCode, search) ||
                Contains(item.ProductName, search) ||
                Contains(item.WarehouseName, search)).ToList();
        }

        return result
            .OrderByDescending(item => item.IsLowStock)
            .ThenBy(item => item.ProductName)
            .ToList();
    }
}

