namespace QuanLyDonHangNoiBo.Application.Features.Users.Commands.Update;

public sealed class UpdateUserRequest
{
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public UserRole Role { get; set; } = UserRole.Sales;
    public Guid? WarehouseId { get; set; }
    public string Locale { get; set; } = "vi";
    public bool IsActive { get; set; } = true;
}


