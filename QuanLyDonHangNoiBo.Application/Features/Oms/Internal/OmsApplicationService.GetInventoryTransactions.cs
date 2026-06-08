namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<InventoryTransactionDto> GetInventoryTransactions(Guid? tenantId, Guid? warehouseId, Guid? skuId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var query = _repository.InventoryTransactions.Where(item => item.TenantId == resolvedTenantId);
        if (warehouseId.HasValue)
        {
            query = query.Where(item => item.WarehouseId == warehouseId.Value);
        }

        if (skuId.HasValue)
        {
            query = query.Where(item => item.SkuId == skuId.Value);
        }

        return query.OrderByDescending(item => item.CreatedAt).Take(200).Select(item =>
            new InventoryTransactionDto(item.Id, item.TenantId, item.WarehouseId, item.SkuId, item.Type, item.Quantity, item.ReferenceCode, item.Note, item.CreatedAt)).ToList();
    }
}

