using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class InventoryStock
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid SkuId { get; set; }
    public int OnHand { get; set; }
    public int Reserved { get; set; }
    public int Available => Math.Max(0, OnHand - Reserved);
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}




