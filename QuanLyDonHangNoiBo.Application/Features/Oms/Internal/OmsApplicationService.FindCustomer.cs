namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private Customer FindCustomer(Guid customerId)
    {
        var customer = _repository.Customers.FirstOrDefault(item => item.Id == customerId)
            ?? throw new KeyNotFoundException("Khach hang khong ton tai.");
        EnsureCanAccessTenant(customer.TenantId);
        return customer;
    }
}

