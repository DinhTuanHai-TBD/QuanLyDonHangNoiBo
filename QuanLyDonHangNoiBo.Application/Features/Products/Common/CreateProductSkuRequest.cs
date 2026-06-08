namespace QuanLyDonHangNoiBo.Application.Features.Products.Common;

public sealed class CreateProductSkuRequest
{
    public string SkuCode { get; set; } = "";
    public string Barcode { get; set; } = "";
    public string Name { get; set; } = "";
    public string Unit { get; set; } = "pcs";
    public decimal Price { get; set; }
    public int LowStockThreshold { get; set; } = 10;
}


