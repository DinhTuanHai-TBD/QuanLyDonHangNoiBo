namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Common;

public sealed class InventoryMutationRequest
{
    public Guid? TenantId { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid SkuId { get; set; }
    public int Quantity { get; set; }
    public string ReferenceCode { get; set; } = "";
    public string Note { get; set; } = "";
}


