
namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Queries.Get_Stocks;

public sealed class GetInventoryStockListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetInventoryStockListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<InventoryStockDto> Handle(GetInventoryStockListQuery query)
    {
        return _service.GetInventoryStocks(query.TenantId, query.WarehouseId, query.Search);
    }
}


