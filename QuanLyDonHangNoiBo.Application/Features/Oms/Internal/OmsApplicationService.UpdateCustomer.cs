namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public CustomerDto UpdateCustomer(Guid customerId, UpdateCustomerRequest request)
    {
        var customer = FindCustomer(customerId);
        ValidateCustomerInput(customer.TenantId, request.Name, request.Phone, customer.Id);

        var before = $"{customer.Name}|{customer.Phone}|{customer.Email}";
        customer.Name = request.Name.Trim();
        customer.Phone = request.Phone.Trim();
        customer.Email = request.Email.Trim();
        customer.Address = request.Address.Trim();
        customer.Province = request.Province.Trim();
        customer.Segment = string.IsNullOrWhiteSpace(request.Segment) ? "Retail" : request.Segment.Trim();
        customer.Note = request.Note.Trim();

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = customer.TenantId,
            EntityName = nameof(Customer),
            EntityId = customer.Id.ToString(),
            Action = "UpdateCustomer",
            BeforeValue = before,
            AfterValue = $"{customer.Name}|{customer.Phone}|{customer.Email}"
        });

        return ToCustomerDto(customer);
    }
}

