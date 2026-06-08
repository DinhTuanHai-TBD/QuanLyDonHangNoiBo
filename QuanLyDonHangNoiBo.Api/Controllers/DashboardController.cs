using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class DashboardController : ApiControllerBase
{
    public DashboardController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet("notifications")]
    [Authorize(Policy = PermissionPolicies.DashboardRead)]
    public ActionResult<IReadOnlyList<NotificationDto>> GetNotifications([FromQuery] Guid? tenantId)
    {
        return Execute(() => Service.GetNotifications(tenantId));
    }

    [HttpGet("dashboard")]
    [HttpGet("reports/dashboard")]
    [Authorize(Policy = PermissionPolicies.DashboardRead)]
    public ActionResult<DashboardDto> GetDashboard([FromQuery] Guid? tenantId)
    {
        return Execute(() => Service.GetDashboard(tenantId));
    }

    [HttpGet("metadata")]
    [Authorize(Policy = PermissionPolicies.DashboardRead)]
    public ActionResult<MetadataDto> GetMetadata([FromQuery] Guid? tenantId)
    {
        return Execute(() => Service.GetMetadata(tenantId));
    }
}




