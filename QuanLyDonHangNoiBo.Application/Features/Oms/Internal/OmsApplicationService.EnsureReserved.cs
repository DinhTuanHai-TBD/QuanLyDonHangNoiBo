namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void EnsureReserved(Order order, Guid? userId)
    {
        var alreadyReserved = _repository.InventoryTransactions.Any(item =>
            item.TenantId == order.TenantId &&
            item.ReferenceCode == order.OrderCode &&
            item.Type == InventoryTransactionType.Reserve);

        if (alreadyReserved)
        {
            return;
        }

        foreach (var item in order.Items)
        {
            var stock = FindStock(order.TenantId, order.WarehouseId, item.SkuId);
            if (stock.Available < item.Quantity)
            {
                throw new InvalidOperationException($"SKU {item.SkuCode} khong du ton kha dung.");
            }

            stock.Reserved += item.Quantity;
            stock.UpdatedAt = DateTimeOffset.UtcNow;
            _repository.AddInventoryTransaction(new InventoryTransaction
            {
                TenantId = order.TenantId,
                WarehouseId = order.WarehouseId,
                SkuId = item.SkuId,
                Type = InventoryTransactionType.Reserve,
                Quantity = item.Quantity,
                ReferenceCode = order.OrderCode,
                Note = $"Reserved by {userId}"
            });
        }
    }
}

