
namespace QuanLyDonHangNoiBo.Application.Features.Warehouses.Commands.Update;

public sealed class UpdateWarehouseCommandHandler
{
    private readonly OmsApplicationService _service;

    public UpdateWarehouseCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public WarehouseDto Handle(UpdateWarehouseCommand command)
    {
        return _service.UpdateWarehouse(command.WarehouseId, command.Request);
    }
}


