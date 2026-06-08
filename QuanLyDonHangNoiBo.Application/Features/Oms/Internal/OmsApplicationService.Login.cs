namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public LoginResponse Login(LoginRequest request)
    {
        var tenant = _repository.Tenants.FirstOrDefault(item =>
            item.Code.Equals(request.TenantCode, StringComparison.OrdinalIgnoreCase))
            ?? throw new InvalidOperationException("Tenant khong ton tai.");

        if (tenant.Status is TenantStatus.Suspended or TenantStatus.Expired)
        {
            throw new InvalidOperationException("Tenant dang bi khoa hoac het han.");
        }

        var user = _repository.Users.FirstOrDefault(item =>
            item.TenantId == tenant.Id &&
            item.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase) &&
            item.IsActive)
            ?? throw new InvalidOperationException("Email hoac mat khau khong dung.");

        if (!QuanLyDonHangNoiBo.Application.Common.Security.PasswordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            throw new InvalidOperationException("Email hoac mat khau khong dung.");
        }

        user.Locale = string.IsNullOrWhiteSpace(request.Locale) ? user.Locale : request.Locale;

        return new LoginResponse("", ToTenantDto(tenant), ToUserDto(user), GetPermissions(user.Role));
    }
}

