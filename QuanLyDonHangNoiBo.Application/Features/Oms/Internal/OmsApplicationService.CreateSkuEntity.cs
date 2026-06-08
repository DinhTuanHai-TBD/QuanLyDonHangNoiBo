namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static ProductSku CreateSkuEntity(Guid tenantId, Guid productId, CreateProductSkuRequest input)
    {
        return new ProductSku
        {
            TenantId = tenantId,
            ProductId = productId,
            SkuCode = input.SkuCode.Trim().ToUpperInvariant(),
            Barcode = input.Barcode.Trim(),
            Name = input.Name.Trim(),
            Unit = string.IsNullOrWhiteSpace(input.Unit) ? "pcs" : input.Unit.Trim(),
            Price = Math.Max(0, input.Price),
            LowStockThreshold = Math.Max(0, input.LowStockThreshold)
        };
    }
}

