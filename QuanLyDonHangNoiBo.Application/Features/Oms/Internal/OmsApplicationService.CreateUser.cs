namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public UserDto CreateUser(CreateUserRequest request)
    {
        var tenantId = ResolveTenantId(request.TenantId);
        EnsureCanCreateUserRole(request.Role);
        ValidateUserInput(tenantId, request.FullName, request.Email, request.Role, request.WarehouseId, null);

        var user = new AppUser
        {
            TenantId = tenantId,
            FullName = request.FullName.Trim(),
            Email = request.Email.Trim().ToLowerInvariant(),
            PasswordHash = QuanLyDonHangNoiBo.Application.Common.Security.PasswordHasher.HashPassword(request.Password),
            Role = request.Role,
            WarehouseId = request.WarehouseId,
            Locale = NormalizeLocale(request.Locale),
            IsActive = request.IsActive
        };

        _repository.AddUser(user);
        _repository.AddAuditLog(new AuditLog
        {
            TenantId = tenantId,
            EntityName = nameof(AppUser),
            EntityId = user.Id.ToString(),
            Action = "CreateUser",
            AfterValue = $"{user.Email}|{user.Role}"
        });

        return ToUserDto(user);
    }
}

