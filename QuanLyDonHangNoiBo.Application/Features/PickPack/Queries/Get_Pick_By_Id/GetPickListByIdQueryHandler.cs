
namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Queries.Get_Pick_By_Id;

public sealed class GetPickListByIdQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetPickListByIdQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public PickListDto Handle(GetPickListByIdQuery query)
    {
        return _service.GetPickList(query.PickListId);
    }
}


