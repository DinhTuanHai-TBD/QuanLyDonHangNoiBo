using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class PickListItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PickListId { get; set; }
    public Guid SkuId { get; set; }
    public string SkuCode { get; set; } = "";
    public string Barcode { get; set; } = "";
    public string ProductName { get; set; } = "";
    public int RequiredQuantity { get; set; }
    public int PickedQuantity { get; set; }
    public bool IsCompleted => PickedQuantity >= RequiredQuantity;
}




