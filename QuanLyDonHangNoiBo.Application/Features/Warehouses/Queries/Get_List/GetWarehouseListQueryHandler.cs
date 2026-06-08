
namespace QuanLyDonHangNoiBo.Application.Features.Warehouses.Queries.Get_List;

public sealed class GetWarehouseListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetWarehouseListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<WarehouseDto> Handle(GetWarehouseListQuery query)
    {
        return _service.GetWarehouses(query.TenantId);
    }
}


