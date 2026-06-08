namespace QuanLyDonHangNoiBo.Application.Features.Auth.Queries.Get_Permissions;

public sealed class GetAuthPermissionListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetAuthPermissionListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<string> Handle(GetAuthPermissionListQuery query)
    {
        return _service.GetRolePermissions()
            .FirstOrDefault(item => item.Role == query.Role)
            ?.Permissions ?? [];
    }
}
