using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public Order AddOrder(Order order)
    {
        lock (_sync)
        {
            _orders.Add(order);
        }

        return order;
    }
}



