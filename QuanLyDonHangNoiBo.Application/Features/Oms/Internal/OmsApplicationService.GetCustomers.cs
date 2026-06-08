namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<CustomerDto> GetCustomers(Guid? tenantId, string? search)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var query = _repository.Customers.Where(item => item.TenantId == resolvedTenantId);

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(item =>
                Contains(item.Code, search) ||
                Contains(item.Name, search) ||
                Contains(item.Phone, search) ||
                Contains(item.Province, search));
        }

        return query.OrderBy(item => item.Name).Select(ToCustomerDto).ToList();
    }
}

