namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public void DeleteCustomer(Guid customerId)
    {
        var customer = FindCustomer(customerId);
        if (_repository.Orders.Any(item => item.CustomerId == customer.Id))
        {
            throw new InvalidOperationException("Khong the xoa khach hang da co don hang.");
        }

        if (!_repository.RemoveCustomer(customer.Id))
        {
            throw new KeyNotFoundException("Khach hang khong ton tai.");
        }
    }
}

