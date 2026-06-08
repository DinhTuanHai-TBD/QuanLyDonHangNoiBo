namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public TenantDto GetTenant(Guid tenantId)
    {
        return ToTenantDto(FindTenant(tenantId));
    }
}

