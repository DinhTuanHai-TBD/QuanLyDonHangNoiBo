namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static UserDto ToUserDto(AppUser user)
    {
        return new UserDto(user.Id, user.TenantId, user.FullName, user.Email, user.Role, user.WarehouseId, user.Locale, user.IsActive);
    }
}

