
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<Shipment> Shipments { get; }
    IReadOnlyList<ProofOfDelivery> ProofOfDeliveries { get; }
    Shipment AddShipment(Shipment shipment);
    ProofOfDelivery AddProofOfDelivery(ProofOfDelivery proofOfDelivery);
}

