
namespace QuanLyDonHangNoiBo.Application.Features.Customers.Queries.Get_List;

public sealed class GetCustomerListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetCustomerListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<CustomerDto> Handle(GetCustomerListQuery query)
    {
        return _service.GetCustomers(query.TenantId, query.Search);
    }
}


