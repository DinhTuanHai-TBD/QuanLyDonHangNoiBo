
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<Tenant> Tenants { get; }
    Tenant AddTenant(Tenant tenant);
    bool RemoveTenant(Guid tenantId);
}

