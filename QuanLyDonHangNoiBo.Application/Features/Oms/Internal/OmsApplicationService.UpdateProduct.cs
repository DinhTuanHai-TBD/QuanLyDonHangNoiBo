namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ProductDto UpdateProduct(Guid productId, UpdateProductRequest request)
    {
        var product = FindProduct(productId);
        ValidateProductInput(product.TenantId, request.Code, request.Name, request.Skus, product.Id);

        var before = $"{product.Code}|{product.Name}|{product.IsActive}";
        product.Code = request.Code.Trim().ToUpperInvariant();
        product.Name = request.Name.Trim();
        product.Category = request.Category.Trim();
        product.IsActive = request.IsActive;

        foreach (var input in request.Skus)
        {
            var skuCode = input.SkuCode.Trim().ToUpperInvariant();
            var existing = product.Skus.FirstOrDefault(item => item.SkuCode.Equals(skuCode, StringComparison.OrdinalIgnoreCase));
            if (existing is null)
            {
                var sku = CreateSkuEntity(product.TenantId, product.Id, input);
                product.Skus.Add(sku);
                _repository.AddSku(sku);
                continue;
            }

            existing.Barcode = input.Barcode.Trim();
            existing.Name = input.Name.Trim();
            existing.Unit = string.IsNullOrWhiteSpace(input.Unit) ? "pcs" : input.Unit.Trim();
            existing.Price = Math.Max(0, input.Price);
            existing.LowStockThreshold = Math.Max(0, input.LowStockThreshold);
        }

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = product.TenantId,
            EntityName = nameof(Product),
            EntityId = product.Id.ToString(),
            Action = "UpdateProduct",
            BeforeValue = before,
            AfterValue = $"{product.Code}|{product.Name}|{product.IsActive}"
        });

        return ToProductDto(product);
    }
}

