
namespace QuanLyDonHangNoiBo.Application.Features.Warehouses.Commands.Delete;

public sealed class DeleteWarehouseCommandHandler
{
    private readonly OmsApplicationService _service;

    public DeleteWarehouseCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public void Handle(DeleteWarehouseCommand command)
    {
        _service.DeleteWarehouse(command.WarehouseId);
    }
}


