
namespace QuanLyDonHangNoiBo.Application.Features.Dashboard.Queries.Get_Metadata;

public sealed class GetMetadataQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetMetadataQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public MetadataDto Handle(GetMetadataQuery query)
    {
        return _service.GetMetadata(query.TenantId);
    }
}


