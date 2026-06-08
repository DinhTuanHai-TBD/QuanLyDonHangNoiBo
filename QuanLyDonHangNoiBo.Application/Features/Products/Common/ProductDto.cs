namespace QuanLyDonHangNoiBo.Application.Features.Products.Common;

public sealed record ProductDto(Guid Id, Guid TenantId, string Code, string Name, string Category, bool IsActive, IReadOnlyList<ProductSkuDto> Skus);


