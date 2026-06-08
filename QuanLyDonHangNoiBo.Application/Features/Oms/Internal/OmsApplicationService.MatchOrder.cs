namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private bool MatchOrder(Order order, string search)
    {
        var customer = _repository.Customers.FirstOrDefault(item => item.Id == order.CustomerId);
        return Contains(order.OrderCode, search) ||
               order.Items.Any(item => Contains(item.SkuCode, search) || Contains(item.ProductName, search)) ||
               (customer is not null && (Contains(customer.Name, search) || Contains(customer.Phone, search)));
    }
}

