using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class ProductSku
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public Guid ProductId { get; set; }
    public string SkuCode { get; set; } = "";
    public string Barcode { get; set; } = "";
    public string Name { get; set; } = "";
    public string Unit { get; set; } = "pcs";
    public decimal Price { get; set; }
    public int LowStockThreshold { get; set; } = 10;
}




