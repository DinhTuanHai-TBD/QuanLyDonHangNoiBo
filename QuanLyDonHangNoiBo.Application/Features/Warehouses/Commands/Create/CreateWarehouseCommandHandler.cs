
namespace QuanLyDonHangNoiBo.Application.Features.Warehouses.Commands.Create;

public sealed class CreateWarehouseCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreateWarehouseCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public WarehouseDto Handle(CreateWarehouseCommand command)
    {
        return _service.CreateWarehouse(command.Request);
    }
}


