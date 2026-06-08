using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class Shipment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public string ShipmentCode { get; set; } = "";
    public Guid OrderId { get; set; }
    public Guid? DriverId { get; set; }
    public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;
    public string RouteName { get; set; } = "";
    public string FailureReason { get; set; } = "";
    public string ProofOfDeliveryUrl { get; set; } = "";
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}




