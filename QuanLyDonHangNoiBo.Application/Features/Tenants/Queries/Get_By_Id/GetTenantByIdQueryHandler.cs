
namespace QuanLyDonHangNoiBo.Application.Features.Tenants.Queries.Get_By_Id;

public sealed class GetTenantByIdQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetTenantByIdQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public TenantDto Handle(GetTenantByIdQuery query)
    {
        return _service.GetTenant(query.TenantId);
    }
}


