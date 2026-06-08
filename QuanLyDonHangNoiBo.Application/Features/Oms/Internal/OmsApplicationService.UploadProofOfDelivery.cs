namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ProofOfDeliveryDto UploadProofOfDelivery(Guid shipmentId, UploadProofOfDeliveryRequest request)
    {
        var shipment = FindShipment(shipmentId);
        var imageUrl = string.IsNullOrWhiteSpace(request.ImageUrl)
            ? $"/pod/{shipment.ShipmentCode}-{DateTimeOffset.UtcNow:yyyyMMddHHmmss}.jpg"
            : request.ImageUrl.Trim();

        var proof = new ProofOfDelivery
        {
            TenantId = shipment.TenantId,
            ShipmentId = shipment.Id,
            UploadedByUserId = request.UserId,
            ImageUrl = imageUrl,
            ReceiverName = request.ReceiverName.Trim(),
            Note = request.Note.Trim(),
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            CapturedAt = DateTimeOffset.UtcNow
        };

        _repository.AddProofOfDelivery(proof);
        shipment.ProofOfDeliveryUrl = imageUrl;
        UpdateShipmentStatus(shipment.Id, new UpdateShipmentStatusRequest(ShipmentStatus.Delivered, "Proof of delivery uploaded", request.CollectedAmount));

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = shipment.TenantId,
            UserId = request.UserId,
            EntityName = nameof(ProofOfDelivery),
            EntityId = proof.Id.ToString(),
            Action = "UploadPOD",
            AfterValue = imageUrl
        });

        return ToProofOfDeliveryDto(proof);
    }
}

