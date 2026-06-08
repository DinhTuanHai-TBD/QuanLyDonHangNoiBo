namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void EnsureStockOut(Order order, Guid? userId)
    {
        var alreadyStockOut = _repository.InventoryTransactions.Any(item =>
            item.TenantId == order.TenantId &&
            item.ReferenceCode == order.OrderCode &&
            item.Type == InventoryTransactionType.StockOut);

        if (alreadyStockOut)
        {
            return;
        }

        foreach (var item in order.Items)
        {
            var stock = FindStock(order.TenantId, order.WarehouseId, item.SkuId);
            if (stock.Reserved >= item.Quantity)
            {
                stock.Reserved -= item.Quantity;
            }
            else if (stock.Available < item.Quantity)
            {
                throw new InvalidOperationException($"SKU {item.SkuCode} khong du ton de xuat kho.");
            }

            stock.OnHand -= item.Quantity;
            stock.UpdatedAt = DateTimeOffset.UtcNow;
            _repository.AddInventoryTransaction(new InventoryTransaction
            {
                TenantId = order.TenantId,
                WarehouseId = order.WarehouseId,
                SkuId = item.SkuId,
                Type = InventoryTransactionType.StockOut,
                Quantity = item.Quantity,
                ReferenceCode = order.OrderCode,
                Note = $"Stock out by {userId}"
            });
        }
    }
}

