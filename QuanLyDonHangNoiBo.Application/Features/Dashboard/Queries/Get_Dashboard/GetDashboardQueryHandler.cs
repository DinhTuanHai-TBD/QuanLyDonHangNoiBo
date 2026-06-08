
namespace QuanLyDonHangNoiBo.Application.Features.Dashboard.Queries.Get_Dashboard;

public sealed class GetDashboardQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetDashboardQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public DashboardDto Handle(GetDashboardQuery query)
    {
        return _service.GetDashboard(query.TenantId);
    }
}


