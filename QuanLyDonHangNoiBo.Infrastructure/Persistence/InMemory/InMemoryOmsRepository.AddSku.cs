using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public ProductSku AddSku(ProductSku sku)
    {
        lock (_sync)
        {
            _skus.Add(sku);
        }

        return sku;
    }
}



