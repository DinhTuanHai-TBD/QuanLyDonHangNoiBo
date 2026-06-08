
namespace QuanLyDonHangNoiBo.Application.Features.Returns.Commands.Update_Status;

public sealed class UpdateReturnStatusCommandHandler
{
    private readonly OmsApplicationService _service;

    public UpdateReturnStatusCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ReturnDto Handle(UpdateReturnStatusCommand command)
    {
        return _service.UpdateReturnStatus(command.ReturnId, command.Request);
    }
}


