namespace QuanLyDonHangNoiBo.Application.Features.Products.Commands.Update;

public sealed class UpdateProductRequest
{
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsActive { get; set; } = true;
    public IReadOnlyList<CreateProductSkuRequest> Skus { get; set; } = [];
}


