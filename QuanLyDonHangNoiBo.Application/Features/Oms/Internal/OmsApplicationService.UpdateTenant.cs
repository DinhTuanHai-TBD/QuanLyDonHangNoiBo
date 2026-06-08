namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public TenantDto UpdateTenant(Guid tenantId, UpdateTenantRequest request)
    {
        var tenant = FindTenant(tenantId);
        ValidateTenantInput(tenant.Code, request.Name, request.UserLimit, request.OrderLimit, request.WarehouseLimit, tenant.Id);

        var before = $"{tenant.Name}|{tenant.Plan}|{tenant.Status}";
        tenant.Name = request.Name.Trim();
        tenant.Plan = string.IsNullOrWhiteSpace(request.Plan) ? tenant.Plan : request.Plan.Trim();
        tenant.Status = request.Status;
        tenant.UserLimit = request.UserLimit;
        tenant.OrderLimit = request.OrderLimit;
        tenant.WarehouseLimit = request.WarehouseLimit;
        tenant.DefaultLocale = NormalizeLocale(request.DefaultLocale);

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = tenant.Id,
            EntityName = nameof(Tenant),
            EntityId = tenant.Id.ToString(),
            Action = "UpdateTenant",
            BeforeValue = before,
            AfterValue = $"{tenant.Name}|{tenant.Plan}|{tenant.Status}"
        });

        return ToTenantDto(tenant);
    }
}

