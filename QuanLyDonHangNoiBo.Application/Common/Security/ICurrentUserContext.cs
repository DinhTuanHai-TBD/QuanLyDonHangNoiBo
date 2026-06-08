namespace QuanLyDonHangNoiBo.Application.Common.Security;

public interface ICurrentUserContext
{
    bool IsAuthenticated { get; }
    Guid? UserId { get; }
    Guid? TenantId { get; }
    string? TenantCode { get; }
    UserRole? Role { get; }
    IReadOnlySet<string> Permissions { get; }
}
