
namespace QuanLyDonHangNoiBo.Application.Features.Users.Commands.Set_Active;

public sealed record SetUserActiveCommand(Guid UserId, bool IsActive, Guid? ChangedByUserId);


