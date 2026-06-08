
namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Cancel;

public sealed class CancelOrderCommandHandler
{
    private readonly OmsApplicationService _service;

    public CancelOrderCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public OrderDetailDto Handle(CancelOrderCommand command)
    {
        return _service.CancelOrder(command.OrderId, command.Note, command.UserId);
    }
}


