
namespace QuanLyDonHangNoiBo.Application.Features.Users.Commands.Create;

public sealed class CreateUserCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreateUserCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public UserDto Handle(CreateUserCommand command)
    {
        return _service.CreateUser(command.Request);
    }
}


