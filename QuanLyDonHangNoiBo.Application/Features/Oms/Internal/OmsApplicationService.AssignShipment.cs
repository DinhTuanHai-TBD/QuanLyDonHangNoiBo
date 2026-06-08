namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ShipmentDto AssignShipment(Guid shipmentId, AssignShipmentRequest request)
    {
        var shipment = FindShipment(shipmentId);
        var driver = _repository.Users.FirstOrDefault(item =>
            item.Id == request.DriverId &&
            item.TenantId == shipment.TenantId &&
            item.Role == UserRole.Driver &&
            item.IsActive)
            ?? throw new InvalidOperationException("Tai xe khong ton tai.");

        shipment.DriverId = driver.Id;
        shipment.RouteName = request.RouteName;
        shipment.Status = ShipmentStatus.Assigned;
        shipment.UpdatedAt = DateTimeOffset.UtcNow;

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = shipment.TenantId,
            EntityName = nameof(Shipment),
            EntityId = shipment.Id.ToString(),
            Action = "AssignDriver",
            AfterValue = driver.FullName
        });

        return ToShipmentDto(shipment);
    }
}

