namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private Guid ResolveTenantId(Guid? tenantId)
    {
        if (_currentUser.IsAuthenticated)
        {
            if (IsCurrentUserSuperAdmin)
            {
                if (tenantId.HasValue && _repository.Tenants.Any(item => item.Id == tenantId.Value))
                {
                    return tenantId.Value;
                }

                return _currentUser.TenantId ?? ResolveDefaultTenantId();
            }

            var currentTenantId = _currentUser.TenantId
                ?? throw new UnauthorizedAccessException("Token khong co tenant_id hop le.");

            if (tenantId.HasValue && tenantId.Value != currentTenantId)
            {
                throw new UnauthorizedAccessException("Khong co quyen truy cap tenant nay.");
            }

            return currentTenantId;
        }

        if (tenantId.HasValue && _repository.Tenants.Any(item => item.Id == tenantId.Value))
        {
            return tenantId.Value;
        }

        return ResolveDefaultTenantId();
    }

    private Guid ResolveDefaultTenantId()
    {
        var tenant = _repository.Tenants.FirstOrDefault(item => item.Status is TenantStatus.Active or TenantStatus.Trial)
            ?? throw new InvalidOperationException("Chua co tenant kha dung.");
        return tenant.Id;
    }
}

