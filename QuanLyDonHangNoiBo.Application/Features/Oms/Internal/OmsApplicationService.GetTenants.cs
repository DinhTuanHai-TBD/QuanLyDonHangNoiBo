namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<TenantDto> GetTenants()
    {
        EnsureSuperAdmin();
        return _repository.Tenants.Select(ToTenantDto).ToList();
    }
}

