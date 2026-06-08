namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ShipmentDto UpdateShipmentStatus(Guid shipmentId, UpdateShipmentStatusRequest request)
    {
        var shipment = FindShipment(shipmentId);
        shipment.Status = request.Status;
        shipment.FailureReason = request.Status == ShipmentStatus.Failed ? request.Note : shipment.FailureReason;
        shipment.UpdatedAt = DateTimeOffset.UtcNow;

        var mappedStatus = request.Status switch
        {
            ShipmentStatus.InTransit => OrderStatus.InTransit,
            ShipmentStatus.Delivered => OrderStatus.Delivered,
            ShipmentStatus.Failed => OrderStatus.Failed,
            ShipmentStatus.Returned => OrderStatus.Returned,
            _ => (OrderStatus?)null
        };

        if (mappedStatus.HasValue)
        {
            UpdateOrderStatusInternal(shipment.OrderId, mappedStatus.Value, request.Note, shipment.DriverId, request.CollectedAmount);
        }

        return ToShipmentDto(shipment);
    }
}

