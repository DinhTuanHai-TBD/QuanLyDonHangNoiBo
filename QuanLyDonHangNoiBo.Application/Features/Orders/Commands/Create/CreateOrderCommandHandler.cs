
namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Create;

public sealed class CreateOrderCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreateOrderCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public OrderDetailDto Handle(CreateOrderCommand command)
    {
        return _service.CreateOrder(command.Request);
    }
}


