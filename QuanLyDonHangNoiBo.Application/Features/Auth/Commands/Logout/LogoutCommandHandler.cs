namespace QuanLyDonHangNoiBo.Application.Features.Auth.Commands.Logout;

public sealed class LogoutCommandHandler
{
    public LogoutResponse Handle(LogoutCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Request.AccessToken))
        {
            throw new InvalidOperationException("Access token khong hop le.");
        }

        return new LogoutResponse(true, "Dang xuat thanh cong.");
    }
}
