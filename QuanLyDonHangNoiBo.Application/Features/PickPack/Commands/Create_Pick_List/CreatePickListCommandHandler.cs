
namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Commands.Create_Pick_List;

public sealed class CreatePickListCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreatePickListCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public PickListDto Handle(CreatePickListCommand command)
    {
        return _service.CreatePickList(command.Request);
    }
}


