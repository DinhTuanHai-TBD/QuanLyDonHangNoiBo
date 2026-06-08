using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsActive { get; set; } = true;
    public List<ProductSku> Skus { get; set; } = [];
}




