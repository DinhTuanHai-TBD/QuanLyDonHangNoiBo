
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<Warehouse> Warehouses { get; }
    Warehouse AddWarehouse(Warehouse warehouse);
    bool RemoveWarehouse(Guid warehouseId);
}

