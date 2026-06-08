using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/demo")]
public sealed class DemoController : ApiControllerBase
{
    public DemoController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet("readiness")]
    [Authorize(Policy = PermissionPolicies.DashboardRead)]
    public ActionResult<DemoReadinessDto> GetDemoReadiness([FromQuery] Guid? tenantId)
    {
        return Execute(() => Service.GetDemoReadiness(tenantId));
    }
}





