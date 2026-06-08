using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public Warehouse AddWarehouse(Warehouse warehouse)
    {
        lock (_sync)
        {
            _warehouses.Add(warehouse);
        }

        return warehouse;
    }
}



