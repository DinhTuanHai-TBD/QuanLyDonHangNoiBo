namespace QuanLyDonHangNoiBo.Application.Features.Permissions.Common;

public sealed record RolePermissionDto(UserRole Role, IReadOnlyList<string> Permissions);


