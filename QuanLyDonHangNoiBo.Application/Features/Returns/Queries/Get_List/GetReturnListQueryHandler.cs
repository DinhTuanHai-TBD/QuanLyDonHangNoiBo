
namespace QuanLyDonHangNoiBo.Application.Features.Returns.Queries.Get_List;

public sealed class GetReturnListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetReturnListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<ReturnDto> Handle(GetReturnListQuery query)
    {
        return _service.GetReturns(query.TenantId, query.Status);
    }
}


