namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public CustomerDto GetCustomer(Guid customerId)
    {
        return ToCustomerDto(FindCustomer(customerId));
    }
}

