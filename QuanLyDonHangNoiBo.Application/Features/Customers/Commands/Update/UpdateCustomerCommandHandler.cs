
namespace QuanLyDonHangNoiBo.Application.Features.Customers.Commands.Update;

public sealed class UpdateCustomerCommandHandler
{
    private readonly OmsApplicationService _service;

    public UpdateCustomerCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public CustomerDto Handle(UpdateCustomerCommand command)
    {
        return _service.UpdateCustomer(command.CustomerId, command.Request);
    }
}


