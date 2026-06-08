
namespace QuanLyDonHangNoiBo.Application.Features.Products.Commands.Create;

public sealed class CreateProductCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreateProductCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ProductDto Handle(CreateProductCommand command)
    {
        return _service.CreateProduct(command.Request);
    }
}


