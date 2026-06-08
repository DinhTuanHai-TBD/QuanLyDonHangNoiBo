namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public WarehouseDto GetWarehouse(Guid warehouseId)
    {
        return ToWarehouseDto(FindWarehouse(warehouseId));
    }
}

