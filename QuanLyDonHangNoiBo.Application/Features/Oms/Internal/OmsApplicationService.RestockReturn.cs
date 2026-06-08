namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void RestockReturn(ReturnRequest returnRequest)
    {
        if (_repository.InventoryTransactions.Any(item => item.ReferenceCode == returnRequest.ReturnCode && item.Type == InventoryTransactionType.Return))
        {
            return;
        }

        var order = FindOrder(returnRequest.OrderId);
        foreach (var item in order.Items)
        {
            var stock = _repository.InventoryStocks.FirstOrDefault(stockItem =>
                stockItem.TenantId == order.TenantId &&
                stockItem.WarehouseId == order.WarehouseId &&
                stockItem.SkuId == item.SkuId)
                ?? _repository.AddInventoryStock(new InventoryStock
                {
                    TenantId = order.TenantId,
                    WarehouseId = order.WarehouseId,
                    SkuId = item.SkuId
                });

            stock.OnHand += item.Quantity;
            stock.UpdatedAt = DateTimeOffset.UtcNow;
            _repository.AddInventoryTransaction(new InventoryTransaction
            {
                TenantId = order.TenantId,
                WarehouseId = order.WarehouseId,
                SkuId = item.SkuId,
                Type = InventoryTransactionType.Return,
                Quantity = item.Quantity,
                ReferenceCode = returnRequest.ReturnCode,
                Note = "Restock from return",
                CreatedAt = DateTimeOffset.UtcNow
            });
        }
    }
}

