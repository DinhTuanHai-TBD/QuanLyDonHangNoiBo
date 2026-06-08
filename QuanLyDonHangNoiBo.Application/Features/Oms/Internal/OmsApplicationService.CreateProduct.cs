namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ProductDto CreateProduct(CreateProductRequest request)
    {
        var tenantId = ResolveTenantId(request.TenantId);
        ValidateProductInput(tenantId, request.Code, request.Name, request.Skus, null);

        var product = new Product
        {
            TenantId = tenantId,
            Code = request.Code.Trim().ToUpperInvariant(),
            Name = request.Name.Trim(),
            Category = request.Category.Trim(),
            IsActive = request.IsActive
        };

        foreach (var input in request.Skus)
        {
            product.Skus.Add(CreateSkuEntity(tenantId, product.Id, input));
        }

        _repository.AddProduct(product);
        _repository.AddAuditLog(new AuditLog
        {
            TenantId = tenantId,
            EntityName = nameof(Product),
            EntityId = product.Id.ToString(),
            Action = "CreateProduct",
            AfterValue = product.Code
        });

        return ToProductDto(product);
    }
}

