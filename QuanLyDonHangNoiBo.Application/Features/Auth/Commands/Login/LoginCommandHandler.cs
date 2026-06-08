namespace QuanLyDonHangNoiBo.Application.Features.Auth.Commands.Login;

public sealed class LoginCommandHandler
{
    private readonly OmsApplicationService _service;

    public LoginCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public LoginResponse Handle(LoginCommand command)
    {
        return _service.Login(command.Request);
    }
}
