using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class ProofOfDelivery
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public Guid ShipmentId { get; set; }
    public Guid? UploadedByUserId { get; set; }
    public string ImageUrl { get; set; } = "";
    public string ReceiverName { get; set; } = "";
    public string Note { get; set; } = "";
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public DateTimeOffset CapturedAt { get; set; } = DateTimeOffset.UtcNow;
}




