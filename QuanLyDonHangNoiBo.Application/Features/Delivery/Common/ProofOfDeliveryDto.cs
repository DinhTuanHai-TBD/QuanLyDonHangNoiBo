namespace QuanLyDonHangNoiBo.Application.Features.Delivery.Common;

public sealed record ProofOfDeliveryDto(
    Guid Id,
    Guid TenantId,
    Guid ShipmentId,
    string ShipmentCode,
    string ImageUrl,
    string ReceiverName,
    string Note,
    double? Latitude,
    double? Longitude,
    DateTimeOffset CapturedAt);


