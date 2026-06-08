
namespace QuanLyDonHangNoiBo.Application.Features.Users.Queries.Get_By_Id;

public sealed class GetUserByIdQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetUserByIdQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public UserDto Handle(GetUserByIdQuery query)
    {
        return _service.GetUser(query.UserId);
    }
}


