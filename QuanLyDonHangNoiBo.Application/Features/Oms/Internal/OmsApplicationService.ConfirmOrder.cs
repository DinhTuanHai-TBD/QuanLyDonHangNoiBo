namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public OrderDetailDto ConfirmOrder(Guid orderId, Guid? userId)
    {
        return UpdateOrderStatusInternal(orderId, OrderStatus.Confirmed, "Confirm order and reserve stock", userId, null);
    }
}

