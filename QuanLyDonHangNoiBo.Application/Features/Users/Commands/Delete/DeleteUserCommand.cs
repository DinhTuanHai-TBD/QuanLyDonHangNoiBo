
namespace QuanLyDonHangNoiBo.Application.Features.Users.Commands.Delete;

public sealed record DeleteUserCommand(Guid UserId, Guid? DeletedByUserId);


