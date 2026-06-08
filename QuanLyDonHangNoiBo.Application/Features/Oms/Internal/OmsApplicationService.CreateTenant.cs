namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public TenantDto CreateTenant(CreateTenantRequest request)
    {
        EnsureSuperAdmin();
        ValidateTenantInput(request.Code, request.Name, request.UserLimit, request.OrderLimit, request.WarehouseLimit, null);

        var tenant = new Tenant
        {
            Code = request.Code.Trim().ToLowerInvariant(),
            Name = request.Name.Trim(),
            Plan = string.IsNullOrWhiteSpace(request.Plan) ? "Starter" : request.Plan.Trim(),
            Status = request.Status,
            UserLimit = request.UserLimit,
            OrderLimit = request.OrderLimit,
            WarehouseLimit = request.WarehouseLimit,
            DefaultLocale = NormalizeLocale(request.DefaultLocale),
            CreatedAt = DateTimeOffset.UtcNow
        };

        _repository.AddTenant(tenant);
        _repository.AddAuditLog(new AuditLog
        {
            TenantId = tenant.Id,
            EntityName = nameof(Tenant),
            EntityId = tenant.Id.ToString(),
            Action = "CreateTenant",
            AfterValue = tenant.Code
        });

        return ToTenantDto(tenant);
    }
}

