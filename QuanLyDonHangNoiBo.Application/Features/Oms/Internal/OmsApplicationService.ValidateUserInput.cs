namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void ValidateUserInput(Guid tenantId, string fullName, string email, UserRole role, Guid? warehouseId, Guid? currentUserId)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new InvalidOperationException("Ho ten user la bat buoc.");
        }

        if (fullName.Trim().Length < 2)
        {
            throw new InvalidOperationException("Ho ten user phai co it nhat 2 ky tu.");
        }

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.'))
        {
            throw new InvalidOperationException("Email user khong hop le.");
        }

        if (!Enum.IsDefined(typeof(UserRole), role))
        {
            throw new InvalidOperationException("Role user khong hop le.");
        }

        var normalizedEmail = email.Trim().ToLowerInvariant();
        var duplicateEmail = _repository.Users.Any(item =>
            item.TenantId == tenantId &&
            item.Id != currentUserId &&
            item.Email.Equals(normalizedEmail, StringComparison.OrdinalIgnoreCase));

        if (duplicateEmail)
        {
            throw new InvalidOperationException("Email user da ton tai trong tenant.");
        }

        if (warehouseId.HasValue && !_repository.Warehouses.Any(item => item.TenantId == tenantId && item.Id == warehouseId.Value && item.IsActive))
        {
            throw new InvalidOperationException("Kho gan cho user khong ton tai hoac da bi khoa.");
        }
    }
}

