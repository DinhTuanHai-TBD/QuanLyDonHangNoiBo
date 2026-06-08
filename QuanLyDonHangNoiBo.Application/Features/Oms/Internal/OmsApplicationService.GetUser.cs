namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public UserDto GetUser(Guid userId)
    {
        return ToUserDto(FindUser(userId));
    }
}

