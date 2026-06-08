
namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Queries.Get_Transactions;

public sealed class GetInventoryTransactionListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetInventoryTransactionListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<InventoryTransactionDto> Handle(GetInventoryTransactionListQuery query)
    {
        return _service.GetInventoryTransactions(query.TenantId, query.WarehouseId, query.SkuId);
    }
}


