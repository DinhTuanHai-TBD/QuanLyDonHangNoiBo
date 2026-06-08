namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private OrderDetailDto UpdateOrderStatusInternal(Guid orderId, OrderStatus targetStatus, string note, Guid? userId, decimal? collectedAmount)
    {
        var order = FindOrder(orderId);
        var oldStatus = order.Status;

        if (oldStatus == targetStatus)
        {
            return ToOrderDetailDto(order);
        }

        if (targetStatus is OrderStatus.Confirmed or OrderStatus.WaitingPick or OrderStatus.Picking or OrderStatus.Packed or OrderStatus.ReadyToShip or OrderStatus.InTransit)
        {
            EnsureReserved(order, userId);
        }

        if (targetStatus is OrderStatus.ReadyToShip or OrderStatus.InTransit or OrderStatus.Delivered)
        {
            EnsureStockOut(order, userId);
            EnsureShipment(order);
        }

        if (targetStatus is OrderStatus.Cancelled or OrderStatus.Returned)
        {
            ReleaseReservation(order, userId);
        }

        order.Status = targetStatus;
        order.UpdatedAt = DateTimeOffset.UtcNow;

        if (targetStatus == OrderStatus.Delivered)
        {
            EnsureCodCollection(order, collectedAmount);
        }

        var shipment = _repository.Shipments.FirstOrDefault(item => item.OrderId == order.Id);
        if (shipment is not null)
        {
            shipment.Status = targetStatus switch
            {
                OrderStatus.InTransit => ShipmentStatus.InTransit,
                OrderStatus.Delivered => ShipmentStatus.Delivered,
                OrderStatus.Failed => ShipmentStatus.Failed,
                OrderStatus.Returned => ShipmentStatus.Returned,
                _ => shipment.Status
            };
            shipment.UpdatedAt = DateTimeOffset.UtcNow;
        }

        _repository.AddOrderStatusHistory(new OrderStatusHistory
        {
            TenantId = order.TenantId,
            OrderId = order.Id,
            OldStatus = oldStatus,
            NewStatus = targetStatus,
            ChangedByUserId = userId,
            Note = note,
            ChangedAt = DateTimeOffset.UtcNow
        });
        _repository.AddAuditLog(new AuditLog
        {
            TenantId = order.TenantId,
            UserId = userId,
            EntityName = nameof(Order),
            EntityId = order.Id.ToString(),
            Action = "ChangeOrderStatus",
            BeforeValue = oldStatus.ToString(),
            AfterValue = targetStatus.ToString()
        });
        _repository.AddNotification(new NotificationItem
        {
            TenantId = order.TenantId,
            Title = "Cap nhat trang thai don",
            Message = $"{order.OrderCode}: {oldStatus} -> {targetStatus}.",
            Severity = targetStatus is OrderStatus.Failed or OrderStatus.Cancelled ? NotificationSeverity.Warning : NotificationSeverity.Info,
            Link = $"/orders/{order.Id}"
        });

        return ToOrderDetailDto(order);
    }
}

