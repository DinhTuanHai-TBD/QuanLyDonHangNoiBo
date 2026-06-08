namespace QuanLyDonHangNoiBo.Application.Features.Warehouses.Common;

public sealed record WarehouseDto(Guid Id, Guid TenantId, string Code, string Name, string Province, string Address, bool IsActive);


