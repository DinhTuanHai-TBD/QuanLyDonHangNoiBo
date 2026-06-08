
namespace QuanLyDonHangNoiBo.Application.Features.Returns.Queries.Get_By_Id;

public sealed class GetReturnByIdQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetReturnByIdQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ReturnDto Handle(GetReturnByIdQuery query)
    {
        return _service.GetReturn(query.ReturnId);
    }
}


