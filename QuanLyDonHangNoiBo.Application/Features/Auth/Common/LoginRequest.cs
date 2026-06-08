namespace QuanLyDonHangNoiBo.Application.Features.Auth.Common;

public sealed record LoginRequest(string TenantCode, string Email, string Password, string Locale);


