namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<PermissionDto> GetPermissions()
    {
        return PermissionCatalog.Select(item => new PermissionDto(item.Key, item.Module, item.Action, item.Description)).ToList();
    }
}

