namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public UserDto SetUserActive(Guid userId, bool isActive, Guid? changedByUserId)
    {
        var user = FindUser(userId);
        var actorUserId = ResolveActorUserId(changedByUserId);
        EnsureCanDisableOrDeleteUser(user);
        EnsureTenantAdminRemains(user, user.Role, isActive);
        if (!isActive && actorUserId == user.Id)
        {
            throw new InvalidOperationException("Khong the khoa chinh user dang thao tac.");
        }

        var before = user.IsActive.ToString();
        user.IsActive = isActive;

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = user.TenantId,
            UserId = actorUserId,
            EntityName = nameof(AppUser),
            EntityId = user.Id.ToString(),
            Action = isActive ? "ActivateUser" : "DeactivateUser",
            BeforeValue = before,
            AfterValue = user.IsActive.ToString()
        });

        return ToUserDto(user);
    }
}

