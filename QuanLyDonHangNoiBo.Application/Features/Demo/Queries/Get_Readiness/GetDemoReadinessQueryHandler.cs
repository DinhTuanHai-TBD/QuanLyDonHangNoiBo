
namespace QuanLyDonHangNoiBo.Application.Features.Demo.Queries.Get_Readiness;

public sealed class GetDemoReadinessQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetDemoReadinessQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public DemoReadinessDto Handle(GetDemoReadinessQuery query)
    {
        return _service.GetDemoReadiness(query.TenantId);
    }
}


