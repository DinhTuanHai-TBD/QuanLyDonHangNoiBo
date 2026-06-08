namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public OrderDetailDto GetOrder(Guid orderId)
    {
        var order = FindOrder(orderId);
        return ToOrderDetailDto(order);
    }
}

