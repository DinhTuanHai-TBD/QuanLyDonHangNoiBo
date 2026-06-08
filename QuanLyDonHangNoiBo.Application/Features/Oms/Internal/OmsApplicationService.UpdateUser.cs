namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public UserDto UpdateUser(Guid userId, UpdateUserRequest request)
    {
        var user = FindUser(userId);
        EnsureCanUpdateUserRole(user, request.Role);
        ValidateUserInput(user.TenantId, request.FullName, request.Email, request.Role, request.WarehouseId, user.Id);
        EnsureTenantAdminRemains(user, request.Role, request.IsActive);

        var before = $"{user.FullName}|{user.Email}|{user.Role}|{user.IsActive}";
        user.FullName = request.FullName.Trim();
        user.Email = request.Email.Trim().ToLowerInvariant();
        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            user.PasswordHash = QuanLyDonHangNoiBo.Application.Common.Security.PasswordHasher.HashPassword(request.Password);
        }

        user.Role = request.Role;
        user.WarehouseId = request.WarehouseId;
        user.Locale = NormalizeLocale(request.Locale);
        user.IsActive = request.IsActive;

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = user.TenantId,
            EntityName = nameof(AppUser),
            EntityId = user.Id.ToString(),
            Action = "UpdateUser",
            BeforeValue = before,
            AfterValue = $"{user.FullName}|{user.Email}|{user.Role}|{user.IsActive}"
        });

        return ToUserDto(user);
    }
}

