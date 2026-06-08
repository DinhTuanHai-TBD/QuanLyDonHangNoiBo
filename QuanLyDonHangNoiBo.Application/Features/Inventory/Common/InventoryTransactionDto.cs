namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Common;

public sealed record InventoryTransactionDto(Guid Id, Guid TenantId, Guid WarehouseId, Guid SkuId, InventoryTransactionType Type, int Quantity, string ReferenceCode, string Note, DateTimeOffset CreatedAt);


