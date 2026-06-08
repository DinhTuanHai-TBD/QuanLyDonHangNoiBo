using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public bool RemoveSku(Guid skuId)
    {
        lock (_sync)
        {
            var sku = _skus.FirstOrDefault(item => item.Id == skuId);
            return sku is not null && _skus.Remove(sku);
        }
    }
}



