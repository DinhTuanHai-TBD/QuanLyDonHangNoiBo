namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Common;

public sealed record InventoryStockDto(
    Guid Id,
    Guid TenantId,
    Guid WarehouseId,
    string WarehouseCode,
    string WarehouseName,
    Guid SkuId,
    string SkuCode,
    string ProductName,
    int OnHand,
    int Reserved,
    int Available,
    int LowStockThreshold,
    bool IsLowStock,
    DateTimeOffset UpdatedAt);


