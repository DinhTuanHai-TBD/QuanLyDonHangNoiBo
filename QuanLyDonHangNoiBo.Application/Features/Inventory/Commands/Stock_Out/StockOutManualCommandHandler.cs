
namespace QuanLyDonHangNoiBo.Application.Features.Inventory.Commands.Stock_Out;

public sealed class StockOutManualCommandHandler
{
    private readonly OmsApplicationService _service;

    public StockOutManualCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public InventoryStockDto Handle(StockOutManualCommand command)
    {
        return _service.StockOutManual(command.Request);
    }
}


