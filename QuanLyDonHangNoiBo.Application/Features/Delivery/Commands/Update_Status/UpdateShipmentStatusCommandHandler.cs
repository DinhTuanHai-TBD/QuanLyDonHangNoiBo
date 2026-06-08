
namespace QuanLyDonHangNoiBo.Application.Features.Delivery.Commands.Update_Status;

public sealed class UpdateShipmentStatusCommandHandler
{
    private readonly OmsApplicationService _service;

    public UpdateShipmentStatusCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ShipmentDto Handle(UpdateShipmentStatusCommand command)
    {
        return _service.UpdateShipmentStatus(command.ShipmentId, command.Request);
    }
}


