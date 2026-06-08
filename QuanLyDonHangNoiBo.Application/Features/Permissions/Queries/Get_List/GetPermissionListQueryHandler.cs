
namespace QuanLyDonHangNoiBo.Application.Features.Permissions.Queries.Get_List;

public sealed class GetPermissionListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetPermissionListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<PermissionDto> Handle(GetPermissionListQuery query)
    {
        return _service.GetPermissions();
    }
}


