namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public OrderDetailDto UpdateOrderStatus(Guid orderId, UpdateOrderStatusRequest request)
    {
        return UpdateOrderStatusInternal(orderId, request.Status, request.Note, request.UserId, null);
    }
}

