namespace QuanLyDonHangNoiBo.Application.Features.ImportExport.Commands.Import_Products;

public sealed class ImportProductsRequest
{
    public Guid? TenantId { get; set; }
    public IReadOnlyList<CreateProductRequest> Products { get; set; } = [];
}


