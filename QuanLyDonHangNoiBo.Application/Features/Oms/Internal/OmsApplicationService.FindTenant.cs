namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private Tenant FindTenant(Guid tenantId)
    {
        EnsureSuperAdmin();
        return _repository.Tenants.FirstOrDefault(item => item.Id == tenantId)
            ?? throw new KeyNotFoundException("Tenant khong ton tai.");
    }
}

