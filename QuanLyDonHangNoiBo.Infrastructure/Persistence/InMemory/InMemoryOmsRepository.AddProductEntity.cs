using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public Product AddProduct(Product product)
    {
        lock (_sync)
        {
            _products.Add(product);
            _skus.AddRange(product.Skus);
        }

        return product;
    }
}



