namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void EnsureTenantAdminRemains(AppUser user, UserRole newRole, bool newIsActive)
    {
        var removesActiveTenantAdmin = user.Role == UserRole.TenantAdmin &&
            user.IsActive &&
            (newRole != UserRole.TenantAdmin || !newIsActive);

        if (!removesActiveTenantAdmin)
        {
            return;
        }

        var activeAdminCount = _repository.Users.Count(item =>
            item.TenantId == user.TenantId &&
            item.Id != user.Id &&
            item.Role == UserRole.TenantAdmin &&
            item.IsActive);

        if (activeAdminCount == 0)
        {
            throw new InvalidOperationException("Tenant phai con it nhat mot TenantAdmin dang hoat dong.");
        }
    }
}

