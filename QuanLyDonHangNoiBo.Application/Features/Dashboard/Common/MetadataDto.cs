namespace QuanLyDonHangNoiBo.Application.Features.Dashboard.Common;

public sealed record MetadataDto(
    Guid TenantId,
    IReadOnlyList<LookupDto> Customers,
    IReadOnlyList<LookupDto> Warehouses,
    IReadOnlyList<LookupDto> Skus,
    IReadOnlyList<LookupDto> Drivers,
    IReadOnlyList<string> UserRoles,
    IReadOnlyList<string> OrderStatuses,
    IReadOnlyList<string> ShipmentStatuses);


