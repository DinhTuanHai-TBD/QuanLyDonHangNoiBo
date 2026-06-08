
namespace QuanLyDonHangNoiBo.Application.Features.Orders.Queries.Get_List;

public sealed class GetOrderListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetOrderListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public PagedResult<OrderSummaryDto> Handle(GetOrderListQuery query)
    {
        return _service.GetOrders(query.Query);
    }
}


