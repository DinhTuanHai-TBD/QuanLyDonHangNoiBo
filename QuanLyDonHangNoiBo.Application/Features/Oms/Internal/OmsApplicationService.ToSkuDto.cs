namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static ProductSkuDto ToSkuDto(ProductSku sku)
    {
        return new ProductSkuDto(sku.Id, sku.ProductId, sku.SkuCode, sku.Barcode, sku.Name, sku.Unit, sku.Price, sku.LowStockThreshold);
    }
}

