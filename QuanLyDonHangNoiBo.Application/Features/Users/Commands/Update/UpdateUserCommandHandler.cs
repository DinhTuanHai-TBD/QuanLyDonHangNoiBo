
namespace QuanLyDonHangNoiBo.Application.Features.Users.Commands.Update;

public sealed class UpdateUserCommandHandler
{
    private readonly OmsApplicationService _service;

    public UpdateUserCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public UserDto Handle(UpdateUserCommand command)
    {
        return _service.UpdateUser(command.UserId, command.Request);
    }
}


