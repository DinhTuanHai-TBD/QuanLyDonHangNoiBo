namespace QuanLyDonHangNoiBo.Application.Features.Auth.Common;

public sealed record LoginResponse(string AccessToken, TenantDto Tenant, UserDto User, IReadOnlyList<string> Permissions);


