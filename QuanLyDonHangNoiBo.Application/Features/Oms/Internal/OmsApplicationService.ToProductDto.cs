namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private ProductDto ToProductDto(Product product)
    {
        return new ProductDto(product.Id, product.TenantId, product.Code, product.Name, product.Category, product.IsActive, product.Skus.Select(ToSkuDto).ToList());
    }
}

