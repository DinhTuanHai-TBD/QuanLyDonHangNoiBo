namespace QuanLyDonHangNoiBo.Application.Features.Users.Common;

public sealed record UserDto(Guid Id, Guid TenantId, string FullName, string Email, UserRole Role, Guid? WarehouseId, string Locale, bool IsActive);


