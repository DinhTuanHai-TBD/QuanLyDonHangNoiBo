namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public WarehouseDto UpdateWarehouse(Guid warehouseId, UpdateWarehouseRequest request)
    {
        var warehouse = FindWarehouse(warehouseId);
        ValidateWarehouseInput(warehouse.TenantId, request.Code, request.Name, warehouse.Id);

        var before = $"{warehouse.Code}|{warehouse.Name}|{warehouse.IsActive}";
        warehouse.Code = request.Code.Trim().ToUpperInvariant();
        warehouse.Name = request.Name.Trim();
        warehouse.Province = request.Province.Trim();
        warehouse.Address = request.Address.Trim();
        warehouse.IsActive = request.IsActive;

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = warehouse.TenantId,
            EntityName = nameof(Warehouse),
            EntityId = warehouse.Id.ToString(),
            Action = "UpdateWarehouse",
            BeforeValue = before,
            AfterValue = $"{warehouse.Code}|{warehouse.Name}|{warehouse.IsActive}"
        });

        return ToWarehouseDto(warehouse);
    }
}

