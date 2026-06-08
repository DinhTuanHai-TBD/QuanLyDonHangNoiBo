
namespace QuanLyDonHangNoiBo.Application.Features.Users.Commands.Set_Active;

public sealed class SetUserActiveCommandHandler
{
    private readonly OmsApplicationService _service;

    public SetUserActiveCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public UserDto Handle(SetUserActiveCommand command)
    {
        return _service.SetUserActive(command.UserId, command.IsActive, command.ChangedByUserId);
    }
}


