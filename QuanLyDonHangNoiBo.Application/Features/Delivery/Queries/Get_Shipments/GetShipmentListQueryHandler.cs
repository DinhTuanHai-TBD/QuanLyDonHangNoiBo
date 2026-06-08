
namespace QuanLyDonHangNoiBo.Application.Features.Delivery.Queries.Get_Shipments;

public sealed class GetShipmentListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetShipmentListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<ShipmentDto> Handle(GetShipmentListQuery query)
    {
        return _service.GetShipments(query.TenantId);
    }
}


