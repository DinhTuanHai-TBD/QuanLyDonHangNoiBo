
namespace QuanLyDonHangNoiBo.Application.Features.Users.Commands.Delete;

public sealed class DeleteUserCommandHandler
{
    private readonly OmsApplicationService _service;

    public DeleteUserCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public void Handle(DeleteUserCommand command)
    {
        _service.DeleteUser(command.UserId, command.DeletedByUserId);
    }
}


