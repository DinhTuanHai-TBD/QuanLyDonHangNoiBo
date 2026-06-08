namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<ProductDto> GetProducts(Guid? tenantId, string? search)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var query = _repository.Products.Where(item => item.TenantId == resolvedTenantId);

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(item =>
                Contains(item.Code, search) ||
                Contains(item.Name, search) ||
                item.Skus.Any(sku => Contains(sku.SkuCode, search) || Contains(sku.Barcode, search)));
        }

        return query.OrderBy(item => item.Name).Select(ToProductDto).ToList();
    }
}

