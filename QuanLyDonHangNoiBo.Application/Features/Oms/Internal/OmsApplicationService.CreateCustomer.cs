namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public CustomerDto CreateCustomer(CreateCustomerRequest request)
    {
        var tenantId = ResolveTenantId(request.TenantId);
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new InvalidOperationException("Ten khach hang la bat buoc.");
        }

        if (string.IsNullOrWhiteSpace(request.Phone))
        {
            throw new InvalidOperationException("So dien thoai khach hang la bat buoc.");
        }

        var duplicate = _repository.Customers.Any(item =>
            item.TenantId == tenantId &&
            item.Phone.Equals(request.Phone.Trim(), StringComparison.OrdinalIgnoreCase));

        if (duplicate)
        {
            throw new InvalidOperationException("So dien thoai khach hang da ton tai.");
        }

        var customer = new Customer
        {
            TenantId = tenantId,
            Code = $"CUS-{_repository.Customers.Count(item => item.TenantId == tenantId) + 1:0000}",
            Name = request.Name.Trim(),
            Phone = request.Phone.Trim(),
            Email = request.Email.Trim(),
            Address = request.Address.Trim(),
            Province = request.Province.Trim(),
            Segment = string.IsNullOrWhiteSpace(request.Segment) ? "Retail" : request.Segment.Trim(),
            Note = request.Note.Trim()
        };

        _repository.AddCustomer(customer);
        _repository.AddAuditLog(new AuditLog
        {
            TenantId = tenantId,
            EntityName = nameof(Customer),
            EntityId = customer.Id.ToString(),
            Action = "CreateCustomer",
            AfterValue = customer.Code
        });

        return ToCustomerDto(customer);
    }
}

