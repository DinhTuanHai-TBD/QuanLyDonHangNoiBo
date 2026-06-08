
namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Commands.Stock_In;

public sealed class StockInCommandHandler
{
    private readonly OmsApplicationService _service;

    public StockInCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public InventoryStockDto Handle(StockInCommand command)
    {
        return _service.StockIn(command.Request);
    }
}


