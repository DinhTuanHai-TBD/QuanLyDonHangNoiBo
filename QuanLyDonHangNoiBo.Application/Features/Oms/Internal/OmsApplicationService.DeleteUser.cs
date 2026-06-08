namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public void DeleteUser(Guid userId, Guid? deletedByUserId)
    {
        var user = FindUser(userId);
        var actorUserId = ResolveActorUserId(deletedByUserId);
        EnsureCanDisableOrDeleteUser(user);
        EnsureTenantAdminRemains(user, UserRole.Sales, false);
        if (actorUserId == user.Id)
        {
            throw new InvalidOperationException("Khong the xoa chinh user dang thao tac.");
        }

        if (!_repository.RemoveUser(user.Id))
        {
            throw new KeyNotFoundException("User khong ton tai.");
        }

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = user.TenantId,
            UserId = actorUserId,
            EntityName = nameof(AppUser),
            EntityId = user.Id.ToString(),
            Action = "DeleteUser",
            BeforeValue = $"{user.Email}|{user.Role}|{user.IsActive}"
        });
    }
}

