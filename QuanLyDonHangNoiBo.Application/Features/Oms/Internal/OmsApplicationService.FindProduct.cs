namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private Product FindProduct(Guid productId)
    {
        var product = _repository.Products.FirstOrDefault(item => item.Id == productId)
            ?? throw new KeyNotFoundException("San pham khong ton tai.");
        EnsureCanAccessTenant(product.TenantId);
        return product;
    }
}

