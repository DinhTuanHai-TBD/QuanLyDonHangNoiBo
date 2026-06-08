namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<RolePermissionDto> GetRolePermissions()
    {
        return Enum.GetValues<UserRole>()
            .Select(role => new RolePermissionDto(role, GetPermissions(role)))
            .ToList();
    }
}

