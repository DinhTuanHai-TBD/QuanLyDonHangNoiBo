
namespace QuanLyDonHangNoiBo.Application.Features.Returns.Commands.Create;

public sealed class CreateReturnCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreateReturnCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ReturnDto Handle(CreateReturnCommand command)
    {
        return _service.CreateReturn(command.Request);
    }
}


