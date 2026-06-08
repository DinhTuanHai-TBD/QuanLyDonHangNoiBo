
namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Update_Status;

public sealed class UpdateOrderStatusCommandHandler
{
    private readonly OmsApplicationService _service;

    public UpdateOrderStatusCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public OrderDetailDto Handle(UpdateOrderStatusCommand command)
    {
        return _service.UpdateOrderStatus(command.OrderId, command.Request);
    }
}


