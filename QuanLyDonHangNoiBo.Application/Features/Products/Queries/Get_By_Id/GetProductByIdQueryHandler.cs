
namespace QuanLyDonHangNoiBo.Application.Features.Products.Queries.Get_By_Id;

public sealed class GetProductByIdQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetProductByIdQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ProductDto Handle(GetProductByIdQuery query)
    {
        return _service.GetProduct(query.ProductId);
    }
}


