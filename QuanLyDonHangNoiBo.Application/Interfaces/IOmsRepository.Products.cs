
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<Product> Products { get; }
    IReadOnlyList<ProductSku> Skus { get; }
    Product AddProduct(Product product);
    bool RemoveProduct(Guid productId);
    ProductSku AddSku(ProductSku sku);
    bool RemoveSku(Guid skuId);
}

