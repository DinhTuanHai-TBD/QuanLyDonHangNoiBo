namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private InventoryStockDto ChangeInventory(InventoryMutationRequest request, InventoryTransactionType type)
    {
        var tenantId = ResolveTenantId(request.TenantId);
        if (request.Quantity <= 0)
        {
            throw new InvalidOperationException("So luong phai lon hon 0.");
        }

        var warehouse = _repository.Warehouses.FirstOrDefault(item => item.Id == request.WarehouseId && item.TenantId == tenantId)
            ?? throw new InvalidOperationException("Kho khong ton tai.");
        var sku = _repository.Skus.FirstOrDefault(item => item.Id == request.SkuId && item.TenantId == tenantId)
            ?? throw new InvalidOperationException("SKU khong ton tai.");
        var stock = _repository.InventoryStocks.FirstOrDefault(item =>
            item.TenantId == tenantId && item.WarehouseId == warehouse.Id && item.SkuId == sku.Id);

        if (stock is null)
        {
            stock = _repository.AddInventoryStock(new InventoryStock
            {
                TenantId = tenantId,
                WarehouseId = warehouse.Id,
                SkuId = sku.Id,
                OnHand = 0,
                Reserved = 0,
                UpdatedAt = DateTimeOffset.UtcNow
            });
        }

        if (type == InventoryTransactionType.StockOut && stock.Available < request.Quantity)
        {
            throw new InvalidOperationException("Khong du ton kha dung de xuat kho.");
        }

        if (type == InventoryTransactionType.StockIn)
        {
            stock.OnHand += request.Quantity;
        }
        else if (type == InventoryTransactionType.StockOut)
        {
            stock.OnHand -= request.Quantity;
        }
        else if (type == InventoryTransactionType.Adjustment)
        {
            stock.OnHand = request.Quantity;
            stock.Reserved = Math.Min(stock.Reserved, stock.OnHand);
        }

        stock.UpdatedAt = DateTimeOffset.UtcNow;
        _repository.AddInventoryTransaction(new InventoryTransaction
        {
            TenantId = tenantId,
            WarehouseId = warehouse.Id,
            SkuId = sku.Id,
            Type = type,
            Quantity = request.Quantity,
            ReferenceCode = string.IsNullOrWhiteSpace(request.ReferenceCode) ? $"INV-{DateTimeOffset.UtcNow:yyMMddHHmmss}" : request.ReferenceCode.Trim(),
            Note = request.Note.Trim(),
            CreatedAt = DateTimeOffset.UtcNow
        });

        return ToInventoryStockDto(stock);
    }
}

