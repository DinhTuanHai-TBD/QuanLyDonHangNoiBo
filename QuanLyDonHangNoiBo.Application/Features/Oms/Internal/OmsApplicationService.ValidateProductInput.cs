namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void ValidateProductInput(Guid tenantId, string code, string name, IReadOnlyList<CreateProductSkuRequest> skus, Guid? currentProductId)
    {
        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidOperationException("Ma va ten san pham la bat buoc.");
        }

        var normalizedCode = code.Trim().ToUpperInvariant();
        if (_repository.Products.Any(item => item.TenantId == tenantId && item.Id != currentProductId && item.Code.Equals(normalizedCode, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Ma san pham da ton tai.");
        }

        foreach (var sku in skus)
        {
            if (string.IsNullOrWhiteSpace(sku.SkuCode) || string.IsNullOrWhiteSpace(sku.Name))
            {
                throw new InvalidOperationException("SKU code va ten SKU la bat buoc.");
            }

            var normalizedSku = sku.SkuCode.Trim().ToUpperInvariant();
            if (_repository.Skus.Any(item => item.TenantId == tenantId && item.ProductId != currentProductId && item.SkuCode.Equals(normalizedSku, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"SKU {normalizedSku} da ton tai.");
            }
        }
    }
}

