namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void ValidateCustomerInput(Guid tenantId, string name, string phone, Guid? currentCustomerId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidOperationException("Ten khach hang la bat buoc.");
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new InvalidOperationException("So dien thoai khach hang la bat buoc.");
        }

        if (_repository.Customers.Any(item =>
            item.TenantId == tenantId &&
            item.Id != currentCustomerId &&
            item.Phone.Equals(phone.Trim(), StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("So dien thoai khach hang da ton tai.");
        }
    }
}

