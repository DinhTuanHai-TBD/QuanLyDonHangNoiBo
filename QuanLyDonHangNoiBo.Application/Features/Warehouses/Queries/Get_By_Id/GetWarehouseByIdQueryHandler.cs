
namespace QuanLyDonHangNoiBo.Application.Features.Warehouses.Queries.Get_By_Id;

public sealed class GetWarehouseByIdQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetWarehouseByIdQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public WarehouseDto Handle(GetWarehouseByIdQuery query)
    {
        return _service.GetWarehouse(query.WarehouseId);
    }
}


