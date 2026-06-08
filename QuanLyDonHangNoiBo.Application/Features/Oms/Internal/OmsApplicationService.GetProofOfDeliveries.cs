namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<ProofOfDeliveryDto> GetProofOfDeliveries(Guid? tenantId, Guid? shipmentId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var query = _repository.ProofOfDeliveries.Where(item => item.TenantId == resolvedTenantId);
        if (shipmentId.HasValue)
        {
            query = query.Where(item => item.ShipmentId == shipmentId.Value);
        }

        return query.OrderByDescending(item => item.CapturedAt).Select(ToProofOfDeliveryDto).ToList();
    }
}

