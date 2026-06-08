using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public Tenant AddTenant(Tenant tenant)
    {
        lock (_sync)
        {
            _tenants.Add(tenant);
        }

        return tenant;
    }
}



