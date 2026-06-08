
namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Commands.Adjust;

public sealed class AdjustInventoryCommandHandler
{
    private readonly OmsApplicationService _service;

    public AdjustInventoryCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public InventoryStockDto Handle(AdjustInventoryCommand command)
    {
        return _service.AdjustInventory(command.Request);
    }
}


