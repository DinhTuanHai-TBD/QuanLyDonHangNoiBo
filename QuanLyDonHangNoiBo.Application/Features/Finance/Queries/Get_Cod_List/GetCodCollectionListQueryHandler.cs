
namespace QuanLyDonHangNoiBo.Application.Features.Finance.Queries.Get_Cod_List;

public sealed class GetCodCollectionListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetCodCollectionListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<CodCollectionDto> Handle(GetCodCollectionListQuery query)
    {
        return _service.GetCodCollections(query.TenantId);
    }
}


