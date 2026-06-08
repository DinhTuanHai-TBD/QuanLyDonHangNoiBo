namespace QuanLyDonHangNoiBo.Application.Features.Products.Commands.Create;

public sealed class CreateProductRequest
{
    public Guid? TenantId { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsActive { get; set; } = true;
    public IReadOnlyList<CreateProductSkuRequest> Skus { get; set; } = [];
}


