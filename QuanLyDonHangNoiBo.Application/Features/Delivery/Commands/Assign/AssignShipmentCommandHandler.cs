
namespace QuanLyDonHangNoiBo.Application.Features.Delivery.Commands.Assign;

public sealed class AssignShipmentCommandHandler
{
    private readonly OmsApplicationService _service;

    public AssignShipmentCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ShipmentDto Handle(AssignShipmentCommand command)
    {
        return _service.AssignShipment(command.ShipmentId, command.Request);
    }
}


