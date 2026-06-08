namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public OrderDetailDto CancelOrder(Guid orderId, string note, Guid? userId)
    {
        return UpdateOrderStatusInternal(orderId, OrderStatus.Cancelled, string.IsNullOrWhiteSpace(note) ? "Cancel order" : note, userId, null);
    }
}

