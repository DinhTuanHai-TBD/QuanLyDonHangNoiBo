namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public WarehouseDto CreateWarehouse(CreateWarehouseRequest request)
    {
        var tenantId = ResolveTenantId(request.TenantId);
        ValidateWarehouseInput(tenantId, request.Code, request.Name, null);

        var warehouse = new Warehouse
        {
            TenantId = tenantId,
            Code = request.Code.Trim().ToUpperInvariant(),
            Name = request.Name.Trim(),
            Province = request.Province.Trim(),
            Address = request.Address.Trim(),
            IsActive = request.IsActive
        };

        _repository.AddWarehouse(warehouse);
        _repository.AddAuditLog(new AuditLog
        {
            TenantId = tenantId,
            EntityName = nameof(Warehouse),
            EntityId = warehouse.Id.ToString(),
            Action = "CreateWarehouse",
            AfterValue = warehouse.Code
        });

        return ToWarehouseDto(warehouse);
    }
}

