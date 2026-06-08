
namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Queries.Get_Pick_List;

public sealed class GetPickListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetPickListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<PickListDto> Handle(GetPickListQuery query)
    {
        return _service.GetPickLists(query.TenantId, query.Status);
    }
}


