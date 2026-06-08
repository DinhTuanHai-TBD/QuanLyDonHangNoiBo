namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private bool IsCurrentUserSuperAdmin => _currentUser.Role == UserRole.SuperAdmin;

    private void EnsureCanAccessTenant(Guid tenantId)
    {
        if (!_currentUser.IsAuthenticated || IsCurrentUserSuperAdmin)
        {
            return;
        }

        if (_currentUser.TenantId != tenantId)
        {
            throw new UnauthorizedAccessException("Khong co quyen truy cap tenant nay.");
        }
    }

    private void EnsureSuperAdmin()
    {
        if (!_currentUser.IsAuthenticated || !IsCurrentUserSuperAdmin)
        {
            throw new UnauthorizedAccessException("Chi SuperAdmin moi co quyen thuc hien thao tac nay.");
        }
    }

    private void EnsureCanCreateUserRole(UserRole role)
    {
        if (!_currentUser.IsAuthenticated || IsCurrentUserSuperAdmin)
        {
            return;
        }

        if (role is UserRole.SuperAdmin or UserRole.TenantAdmin)
        {
            throw new UnauthorizedAccessException("Khong co quyen gan role cap cao.");
        }
    }

    private void EnsureCanUpdateUserRole(AppUser user, UserRole requestedRole)
    {
        if (!_currentUser.IsAuthenticated || IsCurrentUserSuperAdmin)
        {
            return;
        }

        if (user.Role == UserRole.SuperAdmin ||
            requestedRole == UserRole.SuperAdmin ||
            (requestedRole == UserRole.TenantAdmin && user.Role != UserRole.TenantAdmin))
        {
            throw new UnauthorizedAccessException("Khong co quyen thay doi role cap cao.");
        }
    }

    private void EnsureCanDisableOrDeleteUser(AppUser user)
    {
        if (!_currentUser.IsAuthenticated || IsCurrentUserSuperAdmin)
        {
            return;
        }

        if (user.Role is UserRole.SuperAdmin or UserRole.TenantAdmin)
        {
            throw new UnauthorizedAccessException("Khong co quyen khoa hoac xoa user cap cao.");
        }
    }

    private Guid? ResolveActorUserId(Guid? requestedUserId)
    {
        return _currentUser.IsAuthenticated ? _currentUser.UserId : requestedUserId;
    }
}
