
namespace QuanLyDonHangNoiBo.Application.Features.Products.Commands.Update;

public sealed class UpdateProductCommandHandler
{
    private readonly OmsApplicationService _service;

    public UpdateProductCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ProductDto Handle(UpdateProductCommand command)
    {
        return _service.UpdateProduct(command.ProductId, command.Request);
    }
}


