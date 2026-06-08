namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Commands.Scan_Item;

public sealed class ScanPickItemRequest
{
    public Guid? SkuId { get; set; }
    public string SkuCode { get; set; } = "";
    public string Barcode { get; set; } = "";
    public int Quantity { get; set; } = 1;
}


