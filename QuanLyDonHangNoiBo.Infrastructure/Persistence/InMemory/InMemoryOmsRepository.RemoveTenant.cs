using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public bool RemoveTenant(Guid tenantId)
    {
        lock (_sync)
        {
            var tenant = _tenants.FirstOrDefault(item => item.Id == tenantId);
            return tenant is not null && _tenants.Remove(tenant);
        }
    }
}



