namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static WarehouseDto ToWarehouseDto(Warehouse warehouse)
    {
        return new WarehouseDto(warehouse.Id, warehouse.TenantId, warehouse.Code, warehouse.Name, warehouse.Province, warehouse.Address, warehouse.IsActive);
    }
}

