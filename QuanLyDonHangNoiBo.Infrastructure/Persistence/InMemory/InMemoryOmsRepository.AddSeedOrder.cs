using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    private void AddSeedOrder(
            Guid tenantId,
            string orderCode,
            Customer customer,
            Warehouse warehouse,
            OrderStatus status,
            PaymentMethod paymentMethod,
            DateTimeOffset createdAt,
            IReadOnlyList<(ProductSku Sku, int Quantity)> items,
            AppUser? driver,
            ShipmentStatus? shipmentStatus,
            CodStatus? codStatus)
    {
        var order = new Order
        {
            TenantId = tenantId,
            OrderCode = orderCode,
            CustomerId = customer.Id,
            WarehouseId = warehouse.Id,
            Status = status,
            PaymentMethod = paymentMethod,
            ShippingFee = 25000,
            DeliveryAddress = customer.Address,
            InternalNote = "Du lieu mau tu tai lieu OMS",
            CreatedAt = createdAt,
            UpdatedAt = createdAt.AddHours(1),
            SlaDeadline = createdAt.AddHours(status is OrderStatus.Failed ? 12 : 36)
        };

        foreach (var item in items)
        {
            var product = _products.First(productItem => productItem.Id == item.Sku.ProductId);
            order.Items.Add(new OrderItem
            {
                OrderId = order.Id,
                SkuId = item.Sku.Id,
                SkuCode = item.Sku.SkuCode,
                ProductName = $"{product.Name} - {item.Sku.Name}",
                Quantity = item.Quantity,
                UnitPrice = item.Sku.Price
            });
        }

        order.CodAmount = order.Total;
        _orders.Add(order);
        _orderStatusHistories.Add(new OrderStatusHistory
        {
            TenantId = tenantId,
            OrderId = order.Id,
            OldStatus = OrderStatus.Draft,
            NewStatus = status,
            Note = "Seed status",
            ChangedAt = createdAt.AddMinutes(15)
        });

        if (status is OrderStatus.Confirmed or OrderStatus.WaitingPick or OrderStatus.Picking or OrderStatus.Packed)
        {
            foreach (var item in order.Items)
            {
                var stock = _inventoryStocks.First(stockItem => stockItem.WarehouseId == warehouse.Id && stockItem.SkuId == item.SkuId);
                stock.Reserved += item.Quantity;
                _inventoryTransactions.Add(new InventoryTransaction
                {
                    TenantId = tenantId,
                    WarehouseId = warehouse.Id,
                    SkuId = item.SkuId,
                    Type = InventoryTransactionType.Reserve,
                    Quantity = item.Quantity,
                    ReferenceCode = order.OrderCode,
                    Note = "Seed reserve"
                });
            }
        }

        if (status is OrderStatus.ReadyToShip or OrderStatus.InTransit or OrderStatus.Delivered or OrderStatus.Failed)
        {
            foreach (var item in order.Items)
            {
                var stock = _inventoryStocks.First(stockItem => stockItem.WarehouseId == warehouse.Id && stockItem.SkuId == item.SkuId);
                stock.OnHand -= item.Quantity;
                _inventoryTransactions.Add(new InventoryTransaction
                {
                    TenantId = tenantId,
                    WarehouseId = warehouse.Id,
                    SkuId = item.SkuId,
                    Type = InventoryTransactionType.StockOut,
                    Quantity = item.Quantity,
                    ReferenceCode = order.OrderCode,
                    Note = "Seed stock out"
                });
            }
        }

        if (shipmentStatus.HasValue)
        {
            _shipments.Add(new Shipment
            {
                TenantId = tenantId,
                ShipmentCode = $"SHP-{orderCode[^4..]}",
                OrderId = order.Id,
                DriverId = driver?.Id,
                Status = shipmentStatus.Value,
                RouteName = warehouse.Province == "TP.HCM" ? "Tuyen Nam Sai Gon" : "Tuyen noi thanh",
                FailureReason = shipmentStatus == ShipmentStatus.Failed ? "Khach hen giao lai" : "",
                UpdatedAt = createdAt.AddHours(2)
            });
        }

        if (codStatus.HasValue || (status == OrderStatus.Delivered && paymentMethod == PaymentMethod.Cod))
        {
            _codCollections.Add(new CodCollection
            {
                TenantId = tenantId,
                OrderId = order.Id,
                DriverId = driver?.Id,
                ExpectedAmount = order.CodAmount,
                CollectedAmount = codStatus == CodStatus.Mismatch ? order.CodAmount - 50000 : order.CodAmount,
                Status = codStatus ?? CodStatus.Collected,
                CollectedAt = status == OrderStatus.Delivered ? createdAt.AddHours(3) : null,
                ReconciledAt = codStatus == CodStatus.Reconciled ? createdAt.AddHours(5) : null
            });
        }
    }
}



