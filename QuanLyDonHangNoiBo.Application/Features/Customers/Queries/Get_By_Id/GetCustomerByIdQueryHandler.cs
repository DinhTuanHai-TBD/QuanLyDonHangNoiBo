
namespace QuanLyDonHangNoiBo.Application.Features.Customers.Queries.Get_By_Id;

public sealed class GetCustomerByIdQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetCustomerByIdQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public CustomerDto Handle(GetCustomerByIdQuery query)
    {
        return _service.GetCustomer(query.CustomerId);
    }
}


