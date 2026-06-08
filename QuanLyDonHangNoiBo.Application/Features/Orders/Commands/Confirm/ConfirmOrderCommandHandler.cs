
namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Confirm;

public sealed class ConfirmOrderCommandHandler
{
    private readonly OmsApplicationService _service;

    public ConfirmOrderCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public OrderDetailDto Handle(ConfirmOrderCommand command)
    {
        return _service.ConfirmOrder(command.OrderId, command.UserId);
    }
}


