namespace QuanLyDonHangNoiBo.Application.Features.Users.Common;

public sealed class UserActionRequest
{
    public string Note { get; set; } = "";
    public Guid? UserId { get; set; }
}


