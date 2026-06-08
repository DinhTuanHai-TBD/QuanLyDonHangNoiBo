namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private ProofOfDeliveryDto ToProofOfDeliveryDto(ProofOfDelivery proof)
    {
        var shipment = FindShipment(proof.ShipmentId);
        return new ProofOfDeliveryDto(proof.Id, proof.TenantId, proof.ShipmentId, shipment.ShipmentCode, proof.ImageUrl, proof.ReceiverName, proof.Note, proof.Latitude, proof.Longitude, proof.CapturedAt);
    }
}

