
namespace QuanLyDonHangNoiBo.Application.Features.Products.Queries.Get_List;

public sealed class GetProductListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetProductListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<ProductDto> Handle(GetProductListQuery query)
    {
        return _service.GetProducts(query.TenantId, query.Search);
    }
}


