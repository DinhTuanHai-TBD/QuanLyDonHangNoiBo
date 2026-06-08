namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static CustomerDto ToCustomerDto(Customer customer)
    {
        return new CustomerDto(customer.Id, customer.TenantId, customer.Code, customer.Name, customer.Phone, customer.Email, customer.Address, customer.Province, customer.Segment, customer.Note);
    }
}

