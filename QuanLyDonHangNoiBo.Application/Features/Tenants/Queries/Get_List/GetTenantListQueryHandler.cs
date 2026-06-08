
namespace QuanLyDonHangNoiBo.Application.Features.Tenants.Queries.Get_List;

public sealed class GetTenantListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetTenantListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<TenantDto> Handle(GetTenantListQuery query)
    {
        return _service.GetTenants();
    }
}


