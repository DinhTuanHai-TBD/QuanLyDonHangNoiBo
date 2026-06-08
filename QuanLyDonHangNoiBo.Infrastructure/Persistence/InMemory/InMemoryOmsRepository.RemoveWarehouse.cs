using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public bool RemoveWarehouse(Guid warehouseId)
    {
        lock (_sync)
        {
            var warehouse = _warehouses.FirstOrDefault(item => item.Id == warehouseId);
            return warehouse is not null && _warehouses.Remove(warehouse);
        }
    }
}



