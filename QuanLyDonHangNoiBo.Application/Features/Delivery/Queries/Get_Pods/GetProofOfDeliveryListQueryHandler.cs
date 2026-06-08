
namespace QuanLyDonHangNoiBo.Application.Features.Delivery.Queries.Get_Pods;

public sealed class GetProofOfDeliveryListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetProofOfDeliveryListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<ProofOfDeliveryDto> Handle(GetProofOfDeliveryListQuery query)
    {
        return _service.GetProofOfDeliveries(query.TenantId, query.ShipmentId);
    }
}


