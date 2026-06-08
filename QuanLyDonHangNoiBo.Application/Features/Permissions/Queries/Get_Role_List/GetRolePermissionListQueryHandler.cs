
namespace QuanLyDonHangNoiBo.Application.Features.Permissions.Queries.Get_Role_List;

public sealed class GetRolePermissionListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetRolePermissionListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<RolePermissionDto> Handle(GetRolePermissionListQuery query)
    {
        return _service.GetRolePermissions();
    }
}


