namespace QuanLyDonHangNoiBo.Application.Features.Products.Common;

public sealed record ProductSkuDto(Guid Id, Guid ProductId, string SkuCode, string Barcode, string Name, string Unit, decimal Price, int LowStockThreshold);


