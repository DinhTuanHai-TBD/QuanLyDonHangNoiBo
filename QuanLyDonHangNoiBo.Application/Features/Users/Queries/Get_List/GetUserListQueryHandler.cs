
namespace QuanLyDonHangNoiBo.Application.Features.Users.Queries.Get_List;

public sealed class GetUserListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetUserListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<UserDto> Handle(GetUserListQuery query)
    {
        return _service.GetUsers(query.Query);
    }
}


