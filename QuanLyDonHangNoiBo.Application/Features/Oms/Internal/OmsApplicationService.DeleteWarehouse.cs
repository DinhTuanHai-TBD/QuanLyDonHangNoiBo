namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public void DeleteWarehouse(Guid warehouseId)
    {
        var warehouse = FindWarehouse(warehouseId);
        if (_repository.Orders.Any(item => item.WarehouseId == warehouse.Id) ||
            _repository.InventoryStocks.Any(item => item.WarehouseId == warehouse.Id))
        {
            throw new InvalidOperationException("Khong the xoa kho da co ton kho hoac don hang. Hay chuyen IsActive=false.");
        }

        if (!_repository.RemoveWarehouse(warehouse.Id))
        {
            throw new KeyNotFoundException("Kho khong ton tai.");
        }
    }
}

