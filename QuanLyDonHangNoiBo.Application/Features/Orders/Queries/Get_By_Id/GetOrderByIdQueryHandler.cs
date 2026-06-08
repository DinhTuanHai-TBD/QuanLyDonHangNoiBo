
namespace QuanLyDonHangNoiBo.Application.Features.Orders.Queries.Get_By_Id;

public sealed class GetOrderByIdQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetOrderByIdQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public OrderDetailDto Handle(GetOrderByIdQuery query)
    {
        return _service.GetOrder(query.OrderId);
    }
}


