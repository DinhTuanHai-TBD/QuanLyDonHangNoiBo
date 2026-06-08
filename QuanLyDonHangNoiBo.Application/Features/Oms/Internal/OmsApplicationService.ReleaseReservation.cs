namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void ReleaseReservation(Order order, Guid? userId)
    {
        var stockOut = _repository.InventoryTransactions.Any(item =>
            item.TenantId == order.TenantId &&
            item.ReferenceCode == order.OrderCode &&
            item.Type == InventoryTransactionType.StockOut);

        if (stockOut)
        {
            return;
        }

        var hasReservation = _repository.InventoryTransactions.Any(item =>
            item.TenantId == order.TenantId &&
            item.ReferenceCode == order.OrderCode &&
            item.Type == InventoryTransactionType.Reserve);

        if (!hasReservation)
        {
            return;
        }

        foreach (var item in order.Items)
        {
            var stock = FindStock(order.TenantId, order.WarehouseId, item.SkuId);
            stock.Reserved = Math.Max(0, stock.Reserved - item.Quantity);
            stock.UpdatedAt = DateTimeOffset.UtcNow;
            _repository.AddInventoryTransaction(new InventoryTransaction
            {
                TenantId = order.TenantId,
                WarehouseId = order.WarehouseId,
                SkuId = item.SkuId,
                Type = InventoryTransactionType.Release,
                Quantity = item.Quantity,
                ReferenceCode = order.OrderCode,
                Note = $"Release by {userId}"
            });
        }
    }
}

