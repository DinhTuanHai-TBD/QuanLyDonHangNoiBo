
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<Order> Orders { get; }
    IReadOnlyList<OrderStatusHistory> OrderStatusHistories { get; }
    Order AddOrder(Order order);
    OrderStatusHistory AddOrderStatusHistory(OrderStatusHistory history);
}

