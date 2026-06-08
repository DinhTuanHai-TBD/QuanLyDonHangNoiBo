namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private Shipment FindShipment(Guid shipmentId)
    {
        var shipment = _repository.Shipments.FirstOrDefault(item => item.Id == shipmentId)
            ?? throw new KeyNotFoundException("Shipment khong ton tai.");
        EnsureCanAccessTenant(shipment.TenantId);
        return shipment;
    }
}

