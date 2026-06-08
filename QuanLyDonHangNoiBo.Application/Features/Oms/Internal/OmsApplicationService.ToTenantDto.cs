namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private TenantDto ToTenantDto(Tenant tenant)
    {
        return new TenantDto(tenant.Id, tenant.Code, tenant.Name, tenant.Plan, tenant.Status, tenant.UserLimit, tenant.OrderLimit, tenant.WarehouseLimit, tenant.DefaultLocale);
    }
}

