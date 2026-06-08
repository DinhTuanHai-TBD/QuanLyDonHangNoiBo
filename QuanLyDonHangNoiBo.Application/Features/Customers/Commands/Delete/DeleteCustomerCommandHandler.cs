
namespace QuanLyDonHangNoiBo.Application.Features.Customers.Commands.Delete;

public sealed class DeleteCustomerCommandHandler
{
    private readonly OmsApplicationService _service;

    public DeleteCustomerCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public void Handle(DeleteCustomerCommand command)
    {
        _service.DeleteCustomer(command.CustomerId);
    }
}


