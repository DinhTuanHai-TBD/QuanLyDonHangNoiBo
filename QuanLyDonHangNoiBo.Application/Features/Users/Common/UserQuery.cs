namespace QuanLyDonHangNoiBo.Application.Features.Users.Common;

public sealed class UserQuery
{
    public Guid? TenantId { get; set; }
    public string? Search { get; set; }
    public UserRole? Role { get; set; }
    public bool? IsActive { get; set; }
}


