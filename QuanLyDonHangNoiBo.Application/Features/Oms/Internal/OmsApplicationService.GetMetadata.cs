namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public MetadataDto GetMetadata(Guid? tenantId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var drivers = _repository.Users
            .Where(item => item.TenantId == resolvedTenantId && item.Role == UserRole.Driver)
            .Select(item => new LookupDto(item.Id, item.Email, item.FullName))
            .ToList();

        var skus = _repository.Skus
            .Where(item => item.TenantId == resolvedTenantId)
            .Select(item => new LookupDto(item.Id, item.SkuCode, item.Name))
            .OrderBy(item => item.Code)
            .ToList();

        return new MetadataDto(
            resolvedTenantId,
            _repository.Customers.Where(item => item.TenantId == resolvedTenantId).Select(item => new LookupDto(item.Id, item.Code, item.Name)).OrderBy(item => item.Name).ToList(),
            _repository.Warehouses.Where(item => item.TenantId == resolvedTenantId).Select(item => new LookupDto(item.Id, item.Code, item.Name)).OrderBy(item => item.Code).ToList(),
            skus,
            drivers,
            Enum.GetNames<UserRole>(),
            Enum.GetNames<OrderStatus>(),
            Enum.GetNames<ShipmentStatus>());
    }
}

