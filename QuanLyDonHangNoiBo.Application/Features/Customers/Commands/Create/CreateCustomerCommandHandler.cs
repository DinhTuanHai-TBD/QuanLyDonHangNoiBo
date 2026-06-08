
namespace QuanLyDonHangNoiBo.Application.Features.Customers.Commands.Create;

public sealed class CreateCustomerCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreateCustomerCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public CustomerDto Handle(CreateCustomerCommand command)
    {
        return _service.CreateCustomer(command.Request);
    }
}


