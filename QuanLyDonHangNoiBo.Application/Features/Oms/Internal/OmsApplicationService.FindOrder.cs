namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private Order FindOrder(Guid orderId)
    {
        var order = _repository.Orders.FirstOrDefault(item => item.Id == orderId)
            ?? throw new KeyNotFoundException("Don hang khong ton tai.");
        EnsureCanAccessTenant(order.TenantId);
        return order;
    }
}

