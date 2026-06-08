
namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Queries.Get_Transactions;

public sealed record GetInventoryTransactionListQuery(Guid? TenantId, Guid? WarehouseId, Guid? SkuId);


