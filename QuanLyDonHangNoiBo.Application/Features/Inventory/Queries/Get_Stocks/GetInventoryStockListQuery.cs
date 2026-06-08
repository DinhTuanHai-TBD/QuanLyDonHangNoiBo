
namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Queries.Get_Stocks;

public sealed record GetInventoryStockListQuery(Guid? TenantId, Guid? WarehouseId, string? Search);


