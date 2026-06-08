namespace QuanLyDonHangNoiBo.Application.Features.Tenants.Common;

public sealed record TenantDto(Guid Id, string Code, string Name, string Plan, TenantStatus Status, int UserLimit, int OrderLimit, int WarehouseLimit, string DefaultLocale);


