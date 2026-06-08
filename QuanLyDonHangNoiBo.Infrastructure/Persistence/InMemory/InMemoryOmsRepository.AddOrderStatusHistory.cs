using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public OrderStatusHistory AddOrderStatusHistory(OrderStatusHistory history)
    {
        lock (_sync)
        {
            _orderStatusHistories.Add(history);
        }

        return history;
    }
}



