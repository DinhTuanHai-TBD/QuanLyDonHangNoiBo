using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    private Product AddSeedProduct(Guid tenantId, string code, string name, string category, IReadOnlyList<(string SkuCode, string Barcode, string Name, decimal Price, int Threshold)> skuInputs)
    {
        var product = new Product
        {
            TenantId = tenantId,
            Code = code,
            Name = name,
            Category = category
        };

        foreach (var input in skuInputs)
        {
            var sku = new ProductSku
            {
                TenantId = tenantId,
                ProductId = product.Id,
                SkuCode = input.SkuCode,
                Barcode = input.Barcode,
                Name = input.Name,
                Price = input.Price,
                LowStockThreshold = input.Threshold
            };
            product.Skus.Add(sku);
            _skus.Add(sku);
        }

        _products.Add(product);
        return product;
    }
}



