
namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Commands.Scan_Item;

public sealed class ScanPickItemCommandHandler
{
    private readonly OmsApplicationService _service;

    public ScanPickItemCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public PickListDto Handle(ScanPickItemCommand command)
    {
        return _service.ScanPickItem(command.PickListId, command.Request);
    }
}


