namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private ReturnDto ToReturnDto(ReturnRequest returnRequest)
    {
        var order = FindOrder(returnRequest.OrderId);
        var customer = _repository.Customers.First(item => item.Id == order.CustomerId);
        return new ReturnDto(returnRequest.Id, returnRequest.TenantId, order.Id, order.OrderCode, customer.Name, returnRequest.ReturnCode, returnRequest.Status, returnRequest.Reason, returnRequest.RefundAmount, returnRequest.CreatedAt, returnRequest.UpdatedAt);
    }
}

