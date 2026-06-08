namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public void DeleteTenant(Guid tenantId)
    {
        var tenant = FindTenant(tenantId);
        if (_repository.Orders.Any(item => item.TenantId == tenant.Id) || _repository.Users.Any(item => item.TenantId == tenant.Id))
        {
            throw new InvalidOperationException("Khong the xoa tenant da co user hoac don hang. Hay chuyen sang Suspended.");
        }

        if (!_repository.RemoveTenant(tenant.Id))
        {
            throw new KeyNotFoundException("Tenant khong ton tai.");
        }
    }
}

