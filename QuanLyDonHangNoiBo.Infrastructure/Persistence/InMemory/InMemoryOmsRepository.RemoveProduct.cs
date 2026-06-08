using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public bool RemoveProduct(Guid productId)
    {
        lock (_sync)
        {
            var product = _products.FirstOrDefault(item => item.Id == productId);
            if (product is null)
            {
                return false;
            }

            _skus.RemoveAll(item => item.ProductId == productId);
            return _products.Remove(product);
        }
    }
}



