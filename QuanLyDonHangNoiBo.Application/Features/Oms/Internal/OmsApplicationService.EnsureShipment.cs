namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void EnsureShipment(Order order)
    {
        if (_repository.Shipments.Any(item => item.OrderId == order.Id))
        {
            return;
        }

        _repository.AddShipment(new Shipment
        {
            TenantId = order.TenantId,
            ShipmentCode = $"SHP-{DateTimeOffset.UtcNow:yyMMdd}-{_repository.Shipments.Count(item => item.TenantId == order.TenantId) + 1:0000}",
            OrderId = order.Id,
            Status = ShipmentStatus.Pending,
            RouteName = "Chua gan tuyen",
            UpdatedAt = DateTimeOffset.UtcNow
        });
    }
}

