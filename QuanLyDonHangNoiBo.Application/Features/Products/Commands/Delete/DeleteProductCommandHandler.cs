
namespace QuanLyDonHangNoiBo.Application.Features.Products.Commands.Delete;

public sealed class DeleteProductCommandHandler
{
    private readonly OmsApplicationService _service;

    public DeleteProductCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public void Handle(DeleteProductCommand command)
    {
        _service.DeleteProduct(command.ProductId);
    }
}


